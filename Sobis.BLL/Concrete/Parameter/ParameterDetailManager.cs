using AutoMapper;
using LinqKit;
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sobis.BLL.Concrete.Parameter
{
    public class ParameterDetailManager : IParameterDetailService
    {
        private readonly IParameterDetailRepository _repository;
        private readonly IMapper _mapper;
        public ParameterDetailManager(
            IParameterDetailRepository repository,
            ILoggerService loggerService,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(ParameterDetailAddDto entity)
        {
            var result = Validate.ValidateEntity(typeof(ParameterDetailAddDtoValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<ParameterDetailEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(await AddNameControlAsync(entity));

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.AddAsync(orjEntity);
        }
        private async Task<IResult> AddNameControlAsync(ParameterDetailAddDto entity)
        {
            var predicate = PredicateBuilder.New<ParameterDetailEntity>();

            predicate = predicate.And(i => i.ParamDetailName == entity.ParamDetailName && i.ParamId != entity.ParamId);

            var result = await _repository.GetAsync(predicate);
            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return new ErrorResult(Messages.MultipleRecordFound);
                }
            }
            return new SuccessResult();
        }
        public async Task<IResult> AddBulkAsync(IEnumerable<ParameterDetailAddDto> entity)
        {
            var result = Validate.ValidateEntity(typeof(ParameterDetailAddDtoValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<IEnumerable<ParameterDetailEntity>>(entity);

            return await _repository.AddBulkAsync(orjEntity);
        }

        public async Task<IResult> DeleteAsync(DeleteDto deleteDto)
        {
            return await _repository.DeleteAsync(new ParameterDetailEntity { Id = deleteDto.Id });
        }

        public async Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetAllAsync(ParameterDetailDto entity)
        {
            var predicate = PredicateBuilder.New<ParameterDetailEntity>();

            predicate = predicate.And(i => i.Id >= 0);

            if (!string.IsNullOrEmpty(entity.Status))
            {
                predicate = predicate.And(i => i.Status == entity.Status);
            }
            if (!string.IsNullOrEmpty(entity.ParamDetailName))
            {
                predicate = predicate.And(i => i.ParamDetailName.ToUpper().Contains(entity.ParamDetailName.ToUpper()));
            }

            var result = await _repository.GetAllAsync(predicate);
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<ParameterDetailDto>>(
                    _mapper.Map<IEnumerable<ParameterDetailDto>>(result.Data));
            }
            return new ErrorDataResult<IEnumerable<ParameterDetailDto>>(Messages.NotFoundError);
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
        public async Task<IDataResult<ParameterDetailDto>> GetAsync(GetDto entity)
        {
            var kontrolresult = BusinesRules.GetResult(isIdNull(entity.Id));

            if (kontrolresult != null)
            {
                if (!kontrolresult.IsSuccess) return new ErrorDataResult<ParameterDetailDto>(kontrolresult.ResultMessage);
            }
            var result = await _repository.GetAsync(x => x.Id == entity.Id);


            if (result != null)
            {
                var dto = _mapper.Map<ParameterDetailDto>(result.Data);

                return new SuccessDataResult<ParameterDetailDto>(dto);
            }
            return new ErrorDataResult<ParameterDetailDto>();
        }

        public async Task<IResult> UpdateAsync(ParameterDetailAddDto entity)
        {
            var result = Validate.ValidateEntity(typeof(ParameterDetailAddDtoValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<ParameterDetailEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(
                await UpdateNameControlAsync(entity)
                );

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.UpdateAsync(orjEntity);
        }

        private async Task<IResult> UpdateNameControlAsync(ParameterDetailAddDto entity)
        {
            var result = await _repository.GetAsync(x => x.ParamDetailName == entity.ParamDetailName && x.Id != entity.Id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return new ErrorResult(Messages.MultipleRecordFound);
                }
            }
            return new SuccessResult();
        }

        public async Task<IResult> UpdateBulkAsync(IEnumerable<ParameterDetailAddDto> entity)
        {
            var result = Validate.ValidateEntity(typeof(ParameterDetailAddDtoValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<IEnumerable<ParameterDetailEntity>>(entity);

            return await _repository.UpdateBulkAsync(orjEntity);
        }

        public async Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetListByParameterIdAsync(ParameterDetailDto entity)
        {

            var predicate = PredicateBuilder.New<ParameterDetailEntity>();

            predicate = predicate.And(i => i.Id > 0);

            if (entity.ParamIds is not null)
            {
                predicate = predicate.And(i => entity.ParamIds.Contains(i.ParamId));
            }
            else
            {
                if (entity.ParamId > 0)
                {
                    predicate = predicate.And(i => i.ParamId == entity.ParamId);
                }
            }

            if (!string.IsNullOrEmpty(entity.Status))
            {
                predicate = predicate.And(i => i.Status.ToUpper() == entity.Status.ToUpper());
            }

            var result = await _repository.GetAllAsync(predicate);
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<ParameterDetailDto>>(
                    _mapper.Map<IEnumerable<ParameterDetailDto>>(result.Data.OrderBy(x => x.OrderNo)));
            }
            return new ErrorDataResult<IEnumerable<ParameterDetailDto>>(Messages.NotFoundError);
        }

        //public async Task<IResult> AddAsync(ParameterDetailDto entity)
        //{
        //    var result = Validate.ValidateEntity(typeof(ParameterDetailAddDtoValidator), entity);

        //    if (!result.IsSuccess)
        //    {
        //        return result;
        //    }

        //    var orjEntity = _mapper.Map<ParameterDetailEntity>(entity);

        //    var KontrolResult = BusinesRules.GetResult(await AddControlAsync(entity));

        //    if (KontrolResult != null)
        //    {
        //        return new ErrorResult(message: KontrolResult.ResultMessage);
        //    }

        //    return await _repository.AddAsync(orjEntity);
        //}
        //private async Task<IResult> AddControlAsync(ParameterDetailDto entity)
        //{
        //    var result = await _repository.GetAsync(
        //        x => x.ParamDetailName == entity.ParamDetailName &&
        //        x.ParamId == entity.ParamId);
        //    if (result.IsSuccess)
        //    {
        //        if (result.Data != null)
        //        {
        //            return new ErrorResult(Messages.MultipleRecordFound);
        //        }
        //    }
        //    return new SuccessResult();
        //}
        //public async Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetAllAsync(ParameterDetailDto entity)
        //{
        //    var result = await _repository.GetAllAsync(x => x.Status == "E");
        //    if (result.IsSuccess)
        //    {
        //        return new SuccessDataResult<IEnumerable<ParameterDetailDto>>(
        //            _mapper.Map<IEnumerable<ParameterDetailDto>>(result.Data));
        //    }
        //    return new ErrorDataResult<IEnumerable<ParameterDetailDto>>(Messages.NotFoundError);
        //}
        //public async Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetParamDetailByParamId(ParameterDetailDto entity)
        //{
        //    var predicate = PredicateBuilder.True<ParameterDetailEntity>();

        //    predicate = predicate.And(i => i.Id > 0);

        //    if (entity.ParamIds is not null)
        //    {
        //        predicate = predicate.And(i => entity.ParamIds.Contains(i.ParamId));
        //    }
        //    else
        //    {
        //        if (entity.ParamId > 0)
        //        {
        //            predicate = predicate.And(i => i.ParamId == entity.ParamId);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(entity.Status))
        //    {
        //        predicate = predicate.And(i => i.Status.ToUpper() == entity.Status.ToUpper());
        //    }

        //    var result = await _repository.GetAllAsync(predicate);
        //    if (result.IsSuccess)
        //    {
        //        return new SuccessDataResult<IEnumerable<ParameterDetailDto>>(
        //            _mapper.Map<IEnumerable<ParameterDetailDto>>(result.Data.OrderBy(x => x.OrderNo)));
        //    }
        //    return new ErrorDataResult<IEnumerable<ParameterDetailDto>>(Messages.NotFoundError);
        //}
        //public async Task<IDataResult<ParameterDetailDto>> GetAsync(int? ID)
        //{
        //    var kontrolresult = BusinesRules.GetResult(isIdNull(ID));

        //    if (kontrolresult != null)
        //    {
        //        if (!kontrolresult.IsSuccess) return new ErrorDataResult<ParameterDetailDto>(kontrolresult.ResultMessage);
        //    }
        //    var result = await _repository.GetAsync(x => x.Id == ID);


        //    if (result != null)
        //    {
        //        var dto = _mapper.Map<ParameterDetailDto>(result.Data);

        //        return new SuccessDataResult<ParameterDetailDto>(dto);
        //    }
        //    return new ErrorDataResult<ParameterDetailDto>();
        //}
        //private IResult isIdNull(int? id)
        //{
        //    if (id > 0)
        //    {
        //        return new SuccessResult();
        //    }
        //    else
        //    {
        //        return new ErrorResult(AppUserMessages.NullIdError);
        //    }
        //}
        //public async Task<IResult> UpdateAsync(ParameterDetailDto entity)
        //{
        //    var result = await _repository.GetAsync(
        //        x => x.ParamDetailName == entity.ParamDetailName &&
        //        x.ParamId == entity.ParamId);
        //    if (result.IsSuccess)
        //    {
        //        if (result.Data != null)
        //        {
        //            return new ErrorResult(Messages.MultipleRecordFound);
        //        }
        //    }
        //    return new SuccessResult();
        //}


    }
}
