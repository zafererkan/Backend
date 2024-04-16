using Sobis.Core.Entities.Abstract;
using Sobis.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Entities.Concrete
{
    public class DbOptions : IEntity
    {
        public string DbType { get; set; }
        public string DbName { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
    }
}
