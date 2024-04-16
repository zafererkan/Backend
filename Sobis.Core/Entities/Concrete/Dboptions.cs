using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Core.Entities.Concrete
{
    public static class Dboptions
    {
        public static string DbType { get; set; }
        public static string DbName { get; set; }
        public static string DbUser { get; set; }
        public static string DbPassword { get; set; }
    }
}
