using AutoMapper;
using LinqKit;
using Sobis.BLL.Abstract.Category;
using Sobis.BLL.Constants;
using Sobis.BLL.ValidationRules;
using Sobis.Common.Dto;
using Sobis.Common.ValidationRules.FluentValidation;
using Sobis.Core.Utilities.Business;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.DAL.Abstract.Category;
using Sobis.Entities.Concrete;
using Sobis.Entities.Dto.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.BLL.Concrete.Category
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(CategoryAddDto entity)
        {
            var result = Validate.ValidateEntity(typeof(CategoryAddValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<CategoryEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(await AddNameControlAsync(entity));

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.AddAsync(orjEntity);
        }

        private async Task<IResult> AddNameControlAsync(CategoryAddDto entity)
        {
            var predicate = PredicateBuilder.New<CategoryEntity>();

            predicate = predicate.And(i => i.Name == entity.Name);

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
        public async Task<IResult> AddBulkAsync(IEnumerable<CategoryAddDto> entity)
        {
            var result = Validate.ValidateEntity(typeof(CategoryAddValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<IEnumerable<CategoryEntity>>(entity);

            return await _repository.AddBulkAsync(orjEntity);
        }

        public async Task<IResult> DeleteAsync(DeleteDto deleteDto)
        {
            return await _repository.DeleteAsync(new CategoryEntity { Id = deleteDto.Id });
        }
        public async Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync(CategoryDto entity)
        {
            var predicate = PredicateBuilder.New<CategoryEntity>();

            predicate = predicate.And(i => i.Id >= 0);

            if (!string.IsNullOrEmpty(entity.Status))
            {
                predicate = predicate.And(i => i.Status == entity.Status);
            }
            if (!string.IsNullOrEmpty(entity.Name))
            {
                predicate = predicate.And(i => i.Name.Contains(entity.Name, StringComparison.OrdinalIgnoreCase));
            }

            var result = await _repository.GetAllAsync(predicate);
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<CategoryDto>>(
                    _mapper.Map<IEnumerable<CategoryDto>>(result.Data));
            }
            return new ErrorDataResult<IEnumerable<CategoryDto>>(Messages.NotFoundError);
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
        public async Task<IDataResult<CategoryDto>> GetAsync(GetDto entity)
        {
            var kontrolresult = BusinesRules.GetResult(isIdNull(entity.Id));

            if (kontrolresult != null)
            {
                if (!kontrolresult.IsSuccess) return new ErrorDataResult<CategoryDto>(kontrolresult.ResultMessage);
            }
            var result = await _repository.GetAsync(x => x.Id == entity.Id);


            if (result != null)
            {
                var dto = _mapper.Map<CategoryDto>(result.Data);

                return new SuccessDataResult<CategoryDto>(dto);
            }
            return new ErrorDataResult<CategoryDto>();
        }

        public async Task<IResult> UpdateAsync(CategoryUpdateDto entity)
        {
            var result = Validate.ValidateEntity(typeof(CategoryUpdateValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<CategoryEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(
                await UpdateNameControlAsync(entity)
                );

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.UpdateAsync(orjEntity);
        }

        private async Task<IResult> UpdateNameControlAsync(CategoryUpdateDto entity)
        {
            var result = await _repository.GetAsync(x => x.Name == entity.Name && x.Id != entity.Id);

            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return new ErrorResult(Messages.MultipleRecordFound);
                }
            }
            return new SuccessResult();
        }

        public async Task<IResult> UpdateBulkAsync(IEnumerable<CategoryUpdateDto> entity)
        {
            var result = Validate.ValidateEntity(typeof(CategoryUpdateValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<IEnumerable<CategoryEntity>>(entity);

            return await _repository.UpdateBulkAsync(orjEntity);
        }

        public async Task<IDataResult<IEnumerable<CategoryDataDto>>> GetListByIdAsync(GetDto entity)
        {

            var result = await _repository.GetAllAsync(x => x.Status == "E");
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<CategoryDataDto>>(
                    _mapper.Map<IEnumerable<CategoryDataDto>>(result.Data));
            }
            return new ErrorDataResult<IEnumerable<CategoryDataDto>>(Messages.NotFoundError);
        }
    }
}
