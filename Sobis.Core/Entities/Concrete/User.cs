using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sobis.Core.Entities.Abstract;

namespace Sobis.Core.Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public int? AppUserId { get; set; }
        public string Password { get; set; }
        public string PasswordCore { get; set; }
        public string Email { get; set; }
        public string WebService { get; set; }
    }
}
