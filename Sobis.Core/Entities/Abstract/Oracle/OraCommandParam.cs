using System.Collections.Generic;
using System.Reflection;
using Oracle.ManagedDataAccess.Client;

namespace Sobis.Core.Entities.Abstract.Oracle
{
    public class OraCommandParam : IEntity
    {
        public List<OracleParameter> OraParam { get; set; }
        public object Object { get; set; }
        public PropertyInfo Property { get; set; }
    }
}