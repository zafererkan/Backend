using Sobis.Core.Entities.Concrete;
using System.Collections.Generic;

namespace Sobis.Core.Securitiy.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUserEntity user, IEnumerable<AppClaimEntity> operationClaims);
    }
}
