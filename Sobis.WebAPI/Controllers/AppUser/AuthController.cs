using Microsoft.AspNetCore.Mvc;
using Sobis.BLL.Abstract.AppUser;
using Sobis.BLL.Constants;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.Entities.Concrete.ViewModel;
using Sobis.Entities.Dto.AppUser;
using System.Threading.Tasks;

namespace Sobis.WebAPI.Controllers.AppUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// Deneme
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns></returns>
        [HttpPost("LoginAsync")]
        public async Task<IDataResult<UserAccessToken>> LoginAsync(AppUserLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return new ErrorDataResult<UserAccessToken>(userToLogin.ResultMessage);
            }
            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return new SuccessDataResult<UserAccessToken>(new UserAccessToken
                {
                    AccessToken = result.Data,
                    AppUser = userToLogin.Data
                });
            }

            return new ErrorDataResult<UserAccessToken>(Messages.NotFoundError); ;
        }
    }
}
