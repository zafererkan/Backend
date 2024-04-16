using Sobis.Core.Entities.Concrete;

namespace Sobis.Entities.Dto.Category
{
    public class SubCategoryDto : DtoBase
    {
        public int? CategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
}
