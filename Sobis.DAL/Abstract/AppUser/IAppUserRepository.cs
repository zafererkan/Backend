using Sobis.Core.DataAccess.Abstract;
using Sobis.Core.Entities.Concrete;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.DAL.Abstract.AppUser
{
    public interface IAppUserRepository : IEntityRepository<AppUserEntity>
    {
        Task<IEnumerable<AppClaimEntity>> GetClaimsAsync(AppUserEntity entity);
        
        //Task<IEnumerable<AppUserDto>> GetAppUserBySql(AppUserEntity entity);

        Task<IResult> UpdateDefaultCompanyAsync(AppUserUpdateDefaultCompanyDto AppUserUpdateDefaultCompanyDto);
    }
}
