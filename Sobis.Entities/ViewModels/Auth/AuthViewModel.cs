using Sobis.Core.Entities.Abstract;
using Sobis.Core.Securitiy.JWT;
using Sobis.Entities.Dto.AppUser;

namespace Sobis.Entities.ViewModels.Auth
{
    public class AuthViewModel : IEntity
    {
        public AppUserDto User { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}
