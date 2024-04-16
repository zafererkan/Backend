using Sobis.Core.Entities.Concrete;

namespace Sobis.Entities.Dto.Category
{
    public class CategoryDto : DtoBase
    {
        public CategoryDto() { }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
