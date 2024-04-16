using Sobis.Core.Entities.Concrete;
using Sobis.Entities.Concrete.District;
using System.Collections.Generic;

namespace Sobis.Entities.Concrete.City
{
    public class CityEntity : EntityBase
    {
        public string PlaneNo { get; set; }
        public string CityName { get; set; }
        public ICollection<DistrictEntity> Districts { get; set; }
    }
}
