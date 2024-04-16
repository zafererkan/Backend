using Sobis.Core;

namespace Sobis.Entities.Dto.Product
{
    public class ProductDataDto : IDto
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
    }
}
