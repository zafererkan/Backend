using Sobis.Core.DataAccess.Concrete.EntityFrameWork;
using Sobis.DAL.Abstract.District;
using Sobis.DAL.Concrete.EntityFramework.Contexts;
using Sobis.Entities.Concrete.District;

namespace Sobis.DAL.Concrete.EntityFramework.Repositories.District
{
    public class EfDistrictRepository : EfEntityRepositoryBase<DistrictEntity, SbsDbContext>, IDistrictRepository
    {
    }
}
