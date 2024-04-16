using AutoMapper;
using LinqKit;
using Sobis.BLL.Abstract;
using Sobis.BLL.Constants;
using Sobis.BLL.ValidationRules;
using Sobis.Common.Dto;
using Sobis.Common.ValidationRules.FluentValidation.Product;
using Sobis.Core.Utilities.Business;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.DAL.Abstract.Product;
using Sobis.Entities.Concrete.Product;
using Sobis.Entities.Dto.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.BLL.Concrete.Product
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(ProductAddDto entity)
        {
            var result = Validate.ValidateEntity(typeof(ProductAddValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<ProductEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(await AddNameControlAsync(entity));

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.AddAsync(orjEntity);
        }

        private async Task<IResult> AddNameControlAsync(ProductAddDto entity)
        {
            var predicate = PredicateBuilder.New<ProductEntity>();

            predicate = predicate.And(i => i.ProductName == entity.ProductName && i.CategoryId != entity.CategoryId && i.CrUser == entity.CrUser);

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
        public async Task<IResult> AddBulkAsync(IEnumerable<ProductAddDto> entity)
        {
            var result = Validate.ValidateEntity(typeof(ProductAddValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<IEnumerable<ProductEntity>>(entity);

            return await _repository.AddBulkAsync(orjEntity);
        }

        public async Task<IResult> DeleteAsync(DeleteDto deleteDto)
        {
            return await _repository.DeleteAsync(new ProductEntity { Id = deleteDto.Id });
        }

        public async Task<IDataResult<IEnumerable<ProductDto>>> GetAllAsync(ProductDto entity)
        {
            var predicate = PredicateBuilder.New<ProductEntity>();

            predicate = predicate.And(i => i.Id >= 0);

            if (!string.IsNullOrEmpty(entity.Status))
            {
                predicate = predicate.And(i => i.Status == entity.Status);
            }
            if (entity.CategoryId is not null)
            {
                predicate = predicate.And(i => i.CategoryId == entity.CategoryId);
            }
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                predicate = predicate.And(i => i.ProductName.ToUpper().Contains(entity.ProductName.ToUpper()));
            }

            var result = await _repository.GetAllAsync(predicate, x => x.Category);
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<ProductDto>>(
                    _mapper.Map<IEnumerable<ProductDto>>(result.Data));
            }
            return new ErrorDataResult<IEnumerable<ProductDto>>(Messages.NotFoundError);
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
        public async Task<IDataResult<ProductDto>> GetAsync(GetDto entity)
        {
            var kontrolresult = BusinesRules.GetResult(isIdNull(entity.Id));

            if (kontrolresult != null)
            {
                if (!kontrolresult.IsSuccess) return new ErrorDataResult<ProductDto>(kontrolresult.ResultMessage);
            }
            var result = await _repository.GetAsync(x => x.Id == entity.Id);


            if (result != null)
            {
                var dto = _mapper.Map<ProductDto>(result.Data);

                return new SuccessDataResult<ProductDto>(dto);
            }
            return new ErrorDataResult<ProductDto>();
        }

        public async Task<IResult> UpdateAsync(ProductUpdateDto entity)
        {
            var result = Validate.ValidateEntity(typeof(ProductUpdateValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<ProductEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(
                await UpdateNameControlAsync(entity)
                );

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.UpdateAsync(orjEntity);
        }

        private async Task<IResult> UpdateNameControlAsync(ProductUpdateDto entity)
        {
            var result = await _repository.GetAsync(x => x.ProductName == entity.ProductName && x.Id != entity.Id && x.CategoryId == entity.CategoryId
            && x.CrUser == entity.ModUser
            );

            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return new ErrorResult(Messages.MultipleRecordFound);
                }
            }
            return new SuccessResult();
        }

        public async Task<IResult> UpdateBulkAsync(IEnumerable<ProductUpdateDto> entity)
        {
            var result = Validate.ValidateEntity(typeof(ProductUpdateValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var orjEntity = _mapper.Map<IEnumerable<ProductEntity>>(entity);

            return await _repository.UpdateBulkAsync(orjEntity);
        }

        public async Task<IDataResult<IEnumerable<ProductDataDto>>> GetListByIdAsync(GetDto entity)
        {

            var result = await _repository.GetAllAsync(x => x.CategoryId == entity.Id);
            if (result.IsSuccess)
            {
                return new SuccessDataResult<IEnumerable<ProductDataDto>>(
                    _mapper.Map<IEnumerable<ProductDataDto>>(result.Data));
            }
            return new ErrorDataResult<IEnumerable<ProductDataDto>>(Messages.NotFoundError);
        }

    }
}
