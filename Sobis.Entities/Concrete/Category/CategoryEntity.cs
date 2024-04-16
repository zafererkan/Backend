using Sobis.Core.Entities.Concrete;
using Sobis.Entities.Concrete.Category;
using Sobis.Entities.Concrete.Product;
using System.Collections.Generic;

namespace Sobis.Entities.Concrete
{
    public class CategoryEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
        public virtual ICollection<SubCategoryEntity> SubCategories { get; set; }
    }
}
