using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Sobis.Core.Enums;

namespace Sobis.Core.Entities.Abstract.Oracle
{
    public class SqlCommandParam : IEntity
    {
        public string CommandText { get; set; }
        public string Prefix { get; set; } = "T";
        public Operator Operator { get; set; } = Operator.ESIT;
        public IList<object> OraParam { get; set; }
        public object Object { get; set; }
        public PropertyInfo Property { get; set; }
        public object Value { get; set; }
    }
}
