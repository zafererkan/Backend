using AutoMapper;
using Sobis.BLL.Abstract.AppUser;
using Sobis.BLL.BusinessAspects.Autofac;
using Sobis.BLL.Constants;
using Sobis.Core.Entities.Concrete;
using Sobis.Core.Securities;
using Sobis.Core.Securitiy.JWT;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.Entities.Dto.AppUser;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sobis.BLL.Concrete.AppUser
{
    public class AuthManager : IAuthService
    {
        private readonly IAppUserService _AppUserService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public AuthManager(IAppUserService userService, ITokenHelper tokenHelper, IMapper mapper, ISecurityService securityService)
        {
            _AppUserService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _securityService = securityService;
        }
        public async Task<IDataResult<AccessToken>> CreateAccessToken(AppUserDto user)
        {
            var userMap = _mapper.Map<AppUserEntity>(user);

            var claims = await _AppUserService.GetClaims(user);

            if (claims.Data != null)
            {
                if (claims.Data.Count() > 0)
                {
                    var accessToken = _tokenHelper.CreateToken(userMap, claims.Data);
                    return new SuccessDataResult<AccessToken>(AppUserMessages.TokeCreated, accessToken);
                }
                else
                {
                    return new ErrorDataResult<AccessToken>(AppUserMessages.EmptyClaim);
                }
            }
            else
            {
                return new ErrorDataResult<AccessToken>(AppUserMessages.EmptyClaim);
            }
        }

        //[SecuredOperation("zafer")]
        public async Task<IDataResult<AppUserDto>> Login(AppUserLoginDto AppUserLoginDto)
        {
            var userToCheck = await _AppUserService.GetAppUserByEmailorPhone(AppUserLoginDto);
            if (!userToCheck.IsSuccess)
            {
                return new ErrorDataResult<AppUserDto>(userToCheck.ResultMessage);

            }
            else if (userToCheck.Data == null)
            {
                return new ErrorDataResult<AppUserDto>(AppUserMessages.UserNotFound);
            }
            else if (userToCheck.Data.Password != _securityService.Sifrele(AppUserLoginDto.Password))
            {
                return new ErrorDataResult<AppUserDto>(AppUserMessages.WrogPassword);
            }
           userToCheck.Data.Password = null;
            return new SuccessDataResult<AppUserDto>(userToCheck.Data);
        }
        public Task<IResult> UserExists(string UserCode)
        {
            throw new NotImplementedException();
        }
    }
}
