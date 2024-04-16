using AutoMapper;
using Sobis.BLL.Abstract.AppUser;
using Sobis.BLL.BusinessAspects.Autofac;
using Sobis.BLL.Constants;
using Sobis.BLL.ValidationRules;
using Sobis.Common.Dto;
using Sobis.Core.Entities.Concrete;
using Sobis.Core.Logging;
using Sobis.Core.Utilities.Business;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.DAL.Abstract.AppUser;
using Sobis.Entities.Dto.AppUser;
using Sobis.Entities.ValidationRules.FluentValidation.AppUser;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.BLL.Concrete.AppUser
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserRepository _repository;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        public AppUserManager(IAppUserRepository repository, ILoggerService loggerService, IMapper mapper)
        {
            _repository = repository;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        //[ValidationAspect(typeof(AppUserAddDtoValidator))]

        public async Task<IResult> AddAsync(AppUserAddDto entity)
        {
            var result = Validate.ValidateEntity(typeof(AppUserAddDtoValidator), entity);

            if (!result.IsSuccess)
            {
                return result;
            }

            var AppUserEntity = _mapper.Map<AppUserEntity>(entity);

            var KontrolResult = BusinesRules.GetResult(AddControl(entity));

            if (KontrolResult != null)
            {
                return new ErrorResult(message: KontrolResult.ResultMessage);
            }

            return await _repository.AddAsync(AppUserEntity);
        }

        private IResult AddControl(AppUserAddDto entity)
        {

            return new SuccessResult();
        }

        public Task<IDataResult<IEnumerable<AppUserDto>>> GetAllAsync(AppUserDto entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IDataResult<AppUserDto>> GetAsync(GetDto entity)
        {

            var kontrolresult = BusinesRules.GetResult(isIdNull(entity.Id));

            if (kontrolresult != null)
            {
                if (!kontrolresult.IsSuccess) return new ErrorDataResult<AppUserDto>(kontrolresult.ResultMessage);
            }
            var result = await _repository.GetAsync(x => x.Id == entity.Id);


            if (result != null)
            {
                var dto = _mapper.Map<AppUserDto>(result.Data);
                if (dto is not null)
                {
                    dto.Password = null;
                }
                return new SuccessDataResult<AppUserDto>(dto);
            }
            return new ErrorDataResult<AppUserDto>();
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

        public Task<IResult> UpdateAsync(AppUserUpdateDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(DeleteDto deleteDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IEnumerable<AppClaimEntity>>> GetClaims(AppUserDto user)
        {
            var entity = _mapper.Map<AppUserEntity>(user);

            var result = await _repository.GetClaimsAsync(entity);
            return new SuccessDataResult<IEnumerable<AppClaimEntity>>(result);

        }

        //[ValidationAspect(typeof(AppUserLoginDtoValidator))]
        public async Task<IDataResult<AppUserDto>> GetAppUserByEmailorPhone(AppUserLoginDto AppUserLoginDto)
        {
            var Validateresult = Validate.ValidateEntity(typeof(AppUserLoginDtoValidator), AppUserLoginDto);

            if (!Validateresult.IsSuccess)
            {
                return new ErrorDataResult<AppUserDto>(Validateresult.ResultMessage);
            }

            var result = await _repository.GetAsync(x => x.Email == AppUserLoginDto.UserName);

            var entity = _mapper.Map<AppUserDto>(result.Data);

            return new SuccessDataResult<AppUserDto>(entity);
        }

        public async Task<IResult> AddBulkAsync(IEnumerable<AppUserAddDto> entity)
        {
            var AppUserEntity = _mapper.Map<IEnumerable<AppUserEntity>>(entity);

            return await _repository.AddBulkAsync(AppUserEntity);
        }

        public async Task<IResult> UpdateDefaultCompanyAsync(AppUserUpdateDefaultCompanyDto AppUserUpdateDefaultCompanyDto)
        {
            var kontrolresult = BusinesRules.GetResult(isIdNull(AppUserUpdateDefaultCompanyDto.Id), isIdNull(AppUserUpdateDefaultCompanyDto.CompanyId));

            if (kontrolresult != null)
            {
                if (!kontrolresult.IsSuccess) return new ErrorResult(kontrolresult.ResultMessage);
            }

            return await _repository.UpdateDefaultCompanyAsync(AppUserUpdateDefaultCompanyDto);
        }
    }
}
