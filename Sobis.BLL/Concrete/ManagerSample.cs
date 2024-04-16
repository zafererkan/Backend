using AutoMapper;

namespace Sobis.BLL.Concrete
{
    internal class ManagerSample<TEntity, TAddEntity, TUpdateEntity>
    {
        //private readonly IHealthHouseRepository _repository;
        private readonly IMapper _mapper;

        //public ManagerSample(IHealthHouseRepository repository, IMapper mapper)
        //{
        //    _repository = repository;
        //    _mapper = mapper;
        //}
        //public async Task<IResult> AddAsync(TEntityAddDto entity)
        //{
        //    var result = Validate.ValidateEntity(typeof(TEntityAddDtoValidator), entity);

        //    if (!result.IsSuccess)
        //    {
        //        return result;
        //    }

        //    var orjEntity = _mapper.Map<TEntityEntity>(entity);

        //    var KontrolResult = BusinesRules.GetResult(await AddNameControlAsync(entity));

        //    if (KontrolResult != null)
        //    {
        //        return new ErrorResult(message: KontrolResult.ResultMessage);
        //    }

        //    return await _repository.AddAsync(orjEntity);
        //}

        //private async Task<IResult> AddNameControlAsync(TEntityAddDto entity)
        //{
        //    var predicate = PredicateBuilder.New<TEntityEntity>();

        //    predicate = predicate.And(i => i.HealthHouseName == entity.HealthHouseName && i.DepartmentId != entity.DepartmentId);

        //    var result = await _repository.GetAsync(predicate);
        //    if (result.IsSuccess)
        //    {
        //        if (result.Data != null)
        //        {
        //            return new ErrorResult(Messages.MultipleRecordFound);
        //        }
        //    }
        //    return new SuccessResult();
        //}
        //public async Task<IResult> AddBulkAsync(IEnumerable<TEntityAddDto> entity)
        //{
        //    var result = Validate.ValidateEntity(typeof(TEntityAddDtoValidator), entity);

        //    if (!result.IsSuccess)
        //    {
        //        return result;
        //    }

        //    var orjEntity = _mapper.Map<IEnumerable<TEntityEntity>>(entity);

        //    return await _repository.AddBulkAsync(orjEntity);
        //}

        //public async Task<IResult> DeleteAsync(DeleteDto deleteDto)
        //{
        //    return await _repository.DeleteAsync(new TEntityEntity { Id = deleteDto.Id });
        //}

        //public async Task<IDataResult<IEnumerable<TEntityDto>>> GetAllAsync(TEntityDto entity)
        //{
        //    var predicate = PredicateBuilder.New<TEntityEntity>();

        //    predicate = predicate.And(i => i.Id >= 0);

        //    if (!string.IsNullOrEmpty(entity.Status))
        //    {
        //        predicate = predicate.And(i => i.Status == entity.Status);
        //    }
        //    if (!string.IsNullOrEmpty(entity.HealthHouseName))
        //    {
        //        predicate = predicate.And(i => i.HealthHouseName.ToUpper().Contains(entity.HealthHouseName.ToUpper()));
        //    }

        //    var result = await _repository.GetAllAsync(predicate);
        //    if (result.IsSuccess)
        //    {
        //        return new SuccessDataResult<IEnumerable<TEntityDto>>(
        //            _mapper.Map<IEnumerable<TEntityDto>>(result.Data));
        //    }
        //    return new ErrorDataResult<IEnumerable<TEntityDto>>(Messages.NotFoundError);
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
        //public async Task<IDataResult<TEntityDto>> GetAsync(GetDto entity)
        //{
        //    var kontrolresult = BusinesRules.GetResult(isIdNull(entity.Id));

        //    if (kontrolresult != null)
        //    {
        //        if (!kontrolresult.IsSuccess) return new ErrorDataResult<TEntityDto>(kontrolresult.ResultMessage);
        //    }
        //    var result = await _repository.GetAsync(x => x.Id == entity.Id);


        //    if (result != null)
        //    {
        //        var dto = _mapper.Map<TEntityDto>(result.Data);

        //        return new SuccessDataResult<TEntityDto>(dto);
        //    }
        //    return new ErrorDataResult<TEntityDto>();
        //}

        //public async Task<IResult> UpdateAsync(TEntityUpdateDto entity)
        //{
        //    var result = Validate.ValidateEntity(typeof(TEntityUpdateDtoValidator), entity);

        //    if (!result.IsSuccess)
        //    {
        //        return result;
        //    }

        //    var orjEntity = _mapper.Map<TEntityEntity>(entity);

        //    var KontrolResult = BusinesRules.GetResult(
        //        await UpdateNameControlAsync(entity)
        //        );

        //    if (KontrolResult != null)
        //    {
        //        return new ErrorResult(message: KontrolResult.ResultMessage);
        //    }

        //    return await _repository.UpdateAsync(orjEntity);
        //}

        //private async Task<IResult> UpdateNameControlAsync(TEntityUpdateDto entity)
        //{
        //    var result = await _repository.GetAsync(x => x.HealthHouseName == entity.HealthHouseName && x.Id != entity.Id);

        //    if (result.IsSuccess)
        //    {
        //        if (result.Data != null)
        //        {
        //            return new ErrorResult(Messages.MultipleRecordFound);
        //        }
        //    }
        //    return new SuccessResult();
        //}

        //public async Task<IResult> UpdateBulkAsync(IEnumerable<TEntityUpdateDto> entity)
        //{
        //    var result = Validate.ValidateEntity(typeof(TEntityUpdateDtoValidator), entity);

        //    if (!result.IsSuccess)
        //    {
        //        return result;
        //    }

        //    var orjEntity = _mapper.Map<IEnumerable<TEntityEntity>>(entity);

        //    return await _repository.UpdateBulkAsync(orjEntity);
        //}

        //public async Task<IDataResult<IEnumerable<TEntityDataDto>>> GetListByIdAsync(GetDto entity)
        //{

        //    var result = await _repository.GetAllAsync(x => x.DepartmentId == entity.Id);
        //    if (result.IsSuccess)
        //    {
        //        return new SuccessDataResult<IEnumerable<TEntityDataDto>>(
        //            _mapper.Map<IEnumerable<TEntityDataDto>>(result.Data));
        //    }
        //    return new ErrorDataResult<IEnumerable<TEntityDataDto>>(Messages.NotFoundError);
        //}

    }
}
