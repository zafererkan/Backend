using Sobis.Entities.Dto.Product;

namespace Sobis.BLL.Abstract
{
    public interface IProductService : IServiceBase<ProductDto, ProductAddDto, ProductUpdateDto, ProductDataDto>
    {
    }
}
