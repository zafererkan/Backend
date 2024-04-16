using Sobis.Core.Securitiy.JWT;
using Sobis.Entities.Dto.AppUser;

namespace Sobis.Entities.Concrete.ViewModel
{
    public class UserAccessToken
    {
        public AccessToken AccessToken { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}
