using Sobis.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Core.Entities.Concrete
{
    public class AppUserClaimEntity : EntityBase, IEntity
    {
        public int AppUserId { get; set; }
        public int AppClaimId { get; set; }
    }
}
