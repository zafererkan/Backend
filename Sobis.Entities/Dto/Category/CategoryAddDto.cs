using Sobis.Core.Entities.Concrete;

namespace Sobis.Entities.Dto.Category
{
    public class CategoryAddDto : DtoAddBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
