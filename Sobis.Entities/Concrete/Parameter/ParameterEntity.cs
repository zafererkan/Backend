using Sobis.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Entities.Concrete.Parameter
{
    public class ParameterEntity : EntityBase
    {
        public string ParamName { get; set; }
        public virtual ICollection<ParameterDetailEntity> ParametreDetails { get; set; }
    }
}
