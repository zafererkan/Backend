using AutoMapper;
using Sobis.BLL.Abstract.Parameter;
using Sobis.BLL.Constants;
using Sobis.BLL.ValidationRules;
using Sobis.Common.Dto;
using Sobis.Common.ValidationRules.FluentValidation.Parameter;
using Sobis.Core.Logging;
using Sobis.Core.Utilities.Business;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.DAL.Abstract.Parameter;
using Sobis.Entities.Concrete.Parameter;
using Sobis.Entities.Dto.Parameter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.BLL.Concrete.Parameter
{
    public class ParameterManager : IParameterService
    {
        private readonly IParameterRepository _repository;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        public ParameterManager(IParameterRepository repository, ILoggerService loggerService, IMapper mapper)
        {
            _repository = repository;
            _loggerService = loggerService;
            _mapper = mapper;
        }


        public async Task<IResult> AddAsync(ParameterDto entity)
        {
            var result = Validate.ValidateEntity(typeof(ParameterAddDtoValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<ParameterEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(await AddControlAsync(entity));

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.AddAsync(orjEntity);
        }
        private async Task<IResult> AddControlAsync(ParameterDto entity)
        {
            var result = await _repository.GetAsync(x => x.ParamName == entity.ParamName);
            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return new ErrorResult(Messages.MultipleRecordFound);
                }
            }
            return new SuccessResult();
        }
        public Task<IResult> DeleteAsync(DeleteDto deleteDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IEnumerable<ParameterDto>>> GetAllAsync(ParameterDto entity)
        {
            var result = await _repository.GetAllAsync(x => x.Status == "E");
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<ParameterDto>>(
                    _mapper.Map<IEnumerable<ParameterDto>>(result.Data));
            }
            return new ErrorDataResult<IEnumerable<ParameterDto>>(Messages.NotFoundError);
        }

        public async Task<IDataResult<ParameterDto>> GetAsync(int? ID)
        {
            var kontrolresult = BusinesRules.GetResult(isIdNull(ID));

            if (kontrolresult != null)
            {
                if (!kontrolresult.IsSuccess) return new ErrorDataResult<ParameterDto>(kontrolresult.ResultMessage);
            }
            var result = await _repository.GetAsync(x => x.Id == ID);


            if (result != null)
            {
                var dto = _mapper.Map<ParameterDto>(result.Data);

                return new SuccessDataResult<ParameterDto>(dto);
            }
            return new ErrorDataResult<ParameterDto>();
        }
        private IResult isIdNull(int? id)
        {
            if (id > 0)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(AppUserMessages.NullIdError);
            }
        }

        public async Task<IResult> UpdateAsync(ParameterDto entity)
        {
            var KontrolResult = BusinesRules.GetResult(await UpdateControlAsync(entity));

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            var entityOrj = _mapper.Map<ParameterEntity>(entity);

            return await _repository.UpdateAsync(entityOrj);
        }

        private async Task<IResult> UpdateControlAsync(ParameterDto entity)
        {
            var result = await _repository.GetAsync(x => x.ParamName == entity.ParamName);
            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return new ErrorResult(Messages.MultipleRecordFound);
                }
            }
            return new SuccessResult();
        }
    }
}
