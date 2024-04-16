using Sobis.Core;
using Sobis.Entities.Concrete.Parameter;
using System.Collections.Generic;

namespace Sobis.Entities.Dto.Parameter
{
    public class ParameterDto : IDto
    {
        public string ParamName { get; set; }
        public virtual ICollection<ParameterDetailEntity> ParametreDetails { get; set; }
    }
}
