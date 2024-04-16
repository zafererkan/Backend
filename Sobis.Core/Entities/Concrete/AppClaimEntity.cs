using Sobis.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Core.Entities.Concrete
{
    public class AppClaimEntity : EntityBase, IEntity
    {
        public string ClaimCode { get; set; }
        public string ClaimName { get; set; }
    }
}
