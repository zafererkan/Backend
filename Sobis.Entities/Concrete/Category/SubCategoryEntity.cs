using Sobis.Core.Entities.Concrete;
using Sobis.Entities.Concrete.Product;
using System.Collections.Generic;

namespace Sobis.Entities.Concrete.Category
{
    public class SubCategoryEntity : EntityBase
    {
        public int? CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public string SubCategoryName { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
