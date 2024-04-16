using Sobis.Core.Securitiy.JWT;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.AppUser;
using System.Threading.Tasks;

namespace Sobis.BLL.Abstract.AppUser
{
    public interface IAuthService
    {
        Task<IDataResult<AppUserDto>> Login(AppUserLoginDto AppUserLoginDto);
        Task<IDataResult<AccessToken>> CreateAccessToken(AppUserDto user);
        Task<IResult> UserExists(string UserCode);
    }
}
