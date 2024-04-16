using Sobis.Core.Entities.Concrete;

namespace Sobis.Entities.Dto.Category
{
    public class CategoryUpdateDto : DtoUpdateBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
