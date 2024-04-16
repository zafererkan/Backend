using Sobis.Core.DataAccess.Concrete.EntityFrameWork;
using Sobis.DAL.Abstract.Product;
using Sobis.DAL.Concrete.EntityFramework.Contexts;
using Sobis.Entities.Concrete.Product;

namespace Sobis.DAL.Concrete.EntityFramework.Repositories.Product
{
    public class EfProductRepository : EfEntityRepositoryBase<ProductEntity,SbsDbContext>, IProductRepository
    {
    }
}
