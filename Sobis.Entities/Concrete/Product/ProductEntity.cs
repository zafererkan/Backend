using Sobis.Core.Entities.Concrete;
using Sobis.Entities.Concrete.Category;

namespace Sobis.Entities.Concrete.Product
{
    public class ProductEntity : EntityBase
    {
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual SubCategoryEntity SubCategory { get; set; }
        public string Description { get; set; }
        public int? MinBudget { get; set; }
        public int? MaxBudget { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? ProductTypeId { get; set; }
    }
}
