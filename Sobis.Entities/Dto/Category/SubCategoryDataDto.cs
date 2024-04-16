using Sobis.Core;

namespace Sobis.Entities.Dto.Category
{
    public class SubCategoryDataDto : IDto
    {
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
}
