using Sobis.Core.DataAccess.Abstract;
using Sobis.Entities.Concrete.Product;

namespace Sobis.DAL.Abstract.Product
{
    public interface IProductRepository : IEntityRepository<ProductEntity>
    {
    }
}
