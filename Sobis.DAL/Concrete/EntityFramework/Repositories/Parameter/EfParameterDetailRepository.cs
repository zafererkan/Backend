using Sobis.Core.DataAccess.Concrete.EntityFrameWork;
using Sobis.DAL.Abstract.Parameter;
using Sobis.DAL.Concrete.EntityFramework.Contexts;
using Sobis.Entities.Concrete.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.DAL.Concrete.EntityFramework.Repositories.Parameter
{
    public class EfParameterDetailRepository : EfEntityRepositoryBase<ParameterDetailEntity, SbsDbContext>, IParameterDetailRepository
    {
    }
}
