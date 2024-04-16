using Sobis.Core.DataAccess.Concrete.EntityFrameWork;
using Sobis.DAL.Abstract.City;
using Sobis.DAL.Concrete.EntityFramework.Contexts;
using Sobis.Entities.Concrete.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Repositories.City
{
    public class EfCityRepository : EfEntityRepositoryBase<CityEntity, SbsDbContext>, ICityRepository
    {
    }
}
