using Sobis.Core.DataAccess.Concrete.EntityFrameWork;
using Sobis.DAL.Abstract.Category;
using Sobis.DAL.Concrete.EntityFramework.Contexts;
using Sobis.Entities.Concrete;

namespace Sobis.DAL.Concrete.EntityFramework.Repositories.Category
{
    public class EfCategoryRepository : EfEntityRepositoryBase<CategoryEntity, SbsDbContext>, ICategoryRepository
    {
    }
}
