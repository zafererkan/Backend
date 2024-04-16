using Sobis.Core.Entities.Concrete;
using Sobis.Entities.Concrete.City;

namespace Sobis.Entities.Concrete.District
{
    public class DistrictEntity : EntityBase
    {
        public int? CityId { get; set; }
        public virtual CityEntity City { get; set; }
        public string DistrictName { get; set; }
    }
}
