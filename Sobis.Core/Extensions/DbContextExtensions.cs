using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Sobis.Core.Extensions
{
    public static class DbContextExtensions
    {
        
        public static IQueryable<T> GetRecordBySql<T>(this DbContext dbContext, string sql, IEnumerable<DbParameter> parameters)
        {
            return dbContext.Database.SqlQueryRaw<T>(sql, parameters.ToArray());
        }
        private class PropertyMapp
        {
            public string Name { get; set; }
            public Type Type { get; set; }
            public bool IsSame(PropertyMapp mapp)
            {
                if (mapp == null)
                {
                    return false;
                }
                bool same = mapp.Name == Name && mapp.Type == Type;
                return same;
            }
        }
        public static DbTransaction GetDbTransaction(this IDbContextTransaction source)
        {
            return (source as IInfrastructure<DbTransaction>).Instance;
        }
        public static IQueryable<TSource> FromSqlRaw<TSource>
        (this DbContext db, string sql, params object[] parameters)
         where TSource : class
        {
            var item = db.Set<TSource>().FromSqlRaw(sql, parameters);
            return item;
        }
        public static IEnumerable<T> FromSqlQuery<T>
        (this DbContext context, string query, Func<DbDataReader, T> map,
        List<DbParameter> parameters = null, CommandType commandType = CommandType.Text,
        int? commandTimeOutInSeconds = null)
        {
            return FromSqlQuery(context.Database, query, map, parameters,
                                commandType, commandTimeOutInSeconds);
        }

        public static IEnumerable<T> FromSqlQuery<T>
        (this DatabaseFacade database, string query, Func<DbDataReader, T> map,
        List<DbParameter> parameters = null,
        CommandType commandType = CommandType.Text,
        int? commandTimeOutInSeconds = null)
        {
            using (var command = database.GetDbConnection().CreateCommand())
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                var currentTransaction = database.CurrentTransaction;
                if (currentTransaction != null)
                {
                    command.Transaction = currentTransaction.GetDbTransaction();
                }
                command.CommandText = query;
                command.CommandType = commandType;
                if (commandTimeOutInSeconds != null)
                {
                    command.CommandTimeout = (int)commandTimeOutInSeconds;
                }
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        yield return map(result);
                    }
                }
            }
        }
    }
}
