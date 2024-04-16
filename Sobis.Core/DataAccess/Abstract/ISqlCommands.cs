using Sobis.Core.Entities.Abstract.Oracle;
using System;
using System.Linq.Expressions;

namespace Sobis.Core.DataAccess.Abstract.AdoNet.Oracle
{
    public interface ISqlCommands
    {
        /// <summary>
        /// TCommandType parametre olarak aldığı veri tabanı command Type ifade eder.
        /// OracleCommand,  
        /// </summary>
        /// <typeparam name="TCommandType"></typeparam>
        /// <param name="sqlCommandParam"></param>
        /// <returns></returns>
        public string AddSql(SqlCommandParam sqlCommandParam);

        public string GetTypeName(Type type);
        //public OracleDbType GetDbType(PropertyInfo prop);
        public string GetPropertyName<T>(Expression<Func<T>> propertyLambda);

    }
}
