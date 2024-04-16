using AutoMapper;
using LinqKit;
using Sobis.BLL.Abstract.Category;
using Sobis.BLL.Constants;
using Sobis.BLL.ValidationRules;
using Sobis.Common.Dto;
using Sobis.Common.ValidationRules.FluentValidation.Category;
using Sobis.Core.Utilities.Business;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.DAL.Abstract.Category;
using Sobis.Entities.Concrete.Category;
using Sobis.Entities.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.BLL.Concrete.Category
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repository;
        private readonly IMapper _mapper;

        public SubCategoryManager(ISubCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(SubCategoryAddDto entity)
        {
            var result = Validate.ValidateEntity(typeof(SubCategoryAddValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<SubCategoryEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(await AddNameControlAsync(entity));

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.AddAsync(orjEntity);
        }

        private async Task<IResult> AddNameControlAsync(SubCategoryAddDto entity)
        {
            var predicate = PredicateBuilder.New<SubCategoryEntity>();

            predicate = predicate.And(i => i.SubCategoryName == entity.SubCategoryName && i.CategoryId != entity.CategoryId);

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
        public async Task<IResult> AddBulkAsync(IEnumerable<SubCategoryAddDto> entity)
        {
            var result = Validate.ValidateEntity(typeof(SubCategoryAddValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<IEnumerable<SubCategoryEntity>>(entity);

            return await _repository.AddBulkAsync(orjEntity);
        }

        public async Task<IResult> DeleteAsync(DeleteDto deleteDto)
        {
            return await _repository.DeleteAsync(new SubCategoryEntity { Id = deleteDto.Id });
        }

        public async Task<IDataResult<IEnumerable<SubCategoryDto>>> GetAllAsync(SubCategoryDto entity)
        {
            var predicate = PredicateBuilder.New<SubCategoryEntity>();

            predicate = predicate.And(i => i.Id >= 0);

            if (!string.IsNullOrEmpty(entity.Status))
            {
                predicate = predicate.And(i => i.Status == entity.Status);
            }
            if (!string.IsNullOrEmpty(entity.SubCategoryName))
            {
                predicate = predicate.And(i => i.SubCategoryName.ToUpper().Contains(entity.SubCategoryName.ToUpper()));
            }

            var result = await _repository.GetAllAsync(predicate);
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<SubCategoryDto>>(
                    _mapper.Map<IEnumerable<SubCategoryDto>>(result.Data));
            }
            return new ErrorDataResult<IEnumerable<SubCategoryDto>>(Messages.NotFoundError);
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
        public async Task<IDataResult<SubCategoryDto>> GetAsync(GetDto entity)
        {
            var kontrolresult = BusinesRules.GetResult(isIdNull(entity.Id));

            if (kontrolresult != null)
            {
                if (!kontrolresult.IsSuccess) return new ErrorDataResult<SubCategoryDto>(kontrolresult.ResultMessage);
            }
            var result = await _repository.GetAsync(x => x.Id == entity.Id);


            if (result != null)
            {
                var dto = _mapper.Map<SubCategoryDto>(result.Data);

                return new SuccessDataResult<SubCategoryDto>(dto);
            }
            return new ErrorDataResult<SubCategoryDto>();
        }

        public async Task<IResult> UpdateAsync(SubCategoryUpdateDto entity)
        {
            var result = Validate.ValidateEntity(typeof(SubCategoryUpdateValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<SubCategoryEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(
                await UpdateNameControlAsync(entity)
                );

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.UpdateAsync(orjEntity);
        }

        private async Task<IResult> UpdateNameControlAsync(SubCategoryUpdateDto entity)
        {
            var result = await _repository.GetAsync(x => x.SubCategoryName == entity.SubCategoryName && x.CategoryId == entity.CategoryId && x.Id != entity.Id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return new ErrorResult(Messages.MultipleRecordFound);
                }
            }
            return new SuccessResult();
        }

        public async Task<IResult> UpdateBulkAsync(IEnumerable<SubCategoryUpdateDto> entity)
        {
            var result = Validate.ValidateEntity(typeof(SubCategoryUpdateValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<IEnumerable<SubCategoryEntity>>(entity);

            return await _repository.UpdateBulkAsync(orjEntity);
        }

        public async Task<IDataResult<IEnumerable<SubCategoryDataDto>>> GetListByIdAsync(GetDto entity)
        {

            var result = await _repository.GetAllAsync(x => x.CategoryId == entity.Id);
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<SubCategoryDataDto>>(
                    _mapper.Map<IEnumerable<SubCategoryDataDto>>(result.Data));
            }
            return new ErrorDataResult<IEnumerable<SubCategoryDataDto>>(Messages.NotFoundError);
        }
    }
}
