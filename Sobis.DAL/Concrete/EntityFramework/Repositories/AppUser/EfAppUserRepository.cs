using Microsoft.EntityFrameworkCore;
using Sobis.Core.DataAccess.Concrete.EntityFrameWork;
using Sobis.Core.Entities.Abstract;
using Sobis.Core.Entities.Concrete;
using Sobis.Core.Securities;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.DAL.Abstract.AppUser;
using Sobis.DAL.Concrete.EntityFramework.Contexts;
using Sobis.Entities.Dto.AppUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Repositories.AppUser
{
    public class EfAppUserRepository : EfEntityRepositoryBase<AppUserEntity, SbsDbContext>, IAppUserRepository
    {

        private readonly ISecurityService _SecurityService;

        public EfAppUserRepository(ISecurityService securityService)
        {
            _SecurityService = securityService;
        }

        public async Task<IEnumerable<AppClaimEntity>> GetClaimsAsync(AppUserEntity entity)
        {
            using (DbContext context = new SbsDbContext())
            {
                var Query = context.Set<AppClaimEntity>();
                var Query2 = context.Set<AppUserClaimEntity>();
                var result = from q1 in Query
                             join q2 in Query2 on q1.Id equals q2.AppClaimId
                             where q2.AppUserId == entity.Id

                             select new AppClaimEntity { Id = q1.Id, ClaimCode = q1.ClaimCode, ClaimName = q1.ClaimName };
                return await result.ToListAsync();
            }
        }

        public override async Task<IResult> AddAsync(AppUserEntity entity)
        {
            string cryptParola = _SecurityService.Sifrele(entity.Password);
            entity.Password = cryptParola;
            using (DbContext context = new SbsDbContext())
            {
                await context.Set<AppUserEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return new SuccessResult();
            }
        }

        //public async Task<IEnumerable<AppUserDto>> GetAppUserBySql(AppUserEntity entity)
        //{
        //    //string sql = @"";
        //    //IEnumerable<DbParameter> DbParameters = new List<DbParameter>();


        //    //using (DbContext context = new SbsDbContext())
        //    //{
        //    //    new List<DbParameter>() { new DbParameter("@paramName", "") }

        //    //    var es = context.GetRecordBySql<AppUserEntity>("", objects).ToList();
        //    //}
        //    return null;
        //}

        public async Task<IResult> UpdateDefaultCompanyAsync(AppUserUpdateDefaultCompanyDto AppUserUpdateDefaultCompanyDto)
        {
            var entity = new AppUserEntity { Id = AppUserUpdateDefaultCompanyDto.Id, DefaultCompanyId = AppUserUpdateDefaultCompanyDto.CompanyId };
            using (var context = new SbsDbContext())
            {
                var entry = context.Entry(entity);
                context.Entry(entity).Property(x => x.DefaultCompanyId).IsModified = true;
                await context.SaveChangesAsync();
                return new SuccessResult("Update process successful.");
            }
        }
    }
}
