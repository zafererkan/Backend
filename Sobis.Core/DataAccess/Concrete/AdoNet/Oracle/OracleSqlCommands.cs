using Oracle.ManagedDataAccess.Client;
using Sobis.Core.DataAccess.Abstract.AdoNet.Oracle;
using Sobis.Core.Entities.Abstract.Oracle;
using Sobis.Core.Enums;
using Sobis.Core.Extensions;
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Sobis.Core.DataAccess.Concrete.AdoNet.Oracle
{
    public class OracleSqlCommands : ISqlCommands
    {
        public OracleDbType GetDbType(PropertyInfo prop)
        {
            OracleDbType dbtype;

            switch (GetTypeName(prop.PropertyType))
            {
                case "String":
                    dbtype = OracleDbType.Varchar2;
                    break;
                case "AnsiString":
                    dbtype = OracleDbType.Varchar2;
                    break;
                case "AnsiStringFixedLength":
                    dbtype = OracleDbType.Varchar2;
                    break;
                case "StringFixedLength":
                    dbtype = OracleDbType.Varchar2;
                    break;
                case "Byte":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "Int16":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "SByte":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "UInt16":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "Int32":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "Single":
                    dbtype = OracleDbType.Single;
                    break;
                case "Double":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "Date":
                    dbtype = OracleDbType.Date;
                    break;
                case "DateTime":
                    dbtype = OracleDbType.Date;
                    break;

                case "Time":
                    dbtype = OracleDbType.IntervalDS;
                    break;
                case "Binary":
                    dbtype = OracleDbType.Blob;
                    break;
                case "Boolean":
                    dbtype = OracleDbType.Varchar2;
                    break;

                case "Int64":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "UInt64":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "VarNumeric":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "Decimal":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "Currency":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "Nullable`1":
                    dbtype = OracleDbType.Decimal;
                    break;
                case "Object":
                    dbtype = OracleDbType.Varchar2;
                    break;
                case "Guid":
                    dbtype = OracleDbType.Raw;
                    break;

                default:
                    dbtype = OracleDbType.Varchar2;
                    break;
            }
            return dbtype;
        }
        public string GetTypeName(Type type)
        {
            Type nullableType = Nullable.GetUnderlyingType(type);

            bool isNullableType = nullableType != null;

            return isNullableType ? nullableType.Name : type.Name;
        }

        public string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            MemberExpression prop = propertyLambda.Body as MemberExpression;

            return prop?.Member.Name;
        }
        public string AddSql(SqlCommandParam sqlCommandParam)
        {
            if (sqlCommandParam.Property != null)
            {
                object value = sqlCommandParam.Property.GetValue(sqlCommandParam.Object, null);
                if (sqlCommandParam.Property.PropertyType.Name == "String")
                {
                    if (value != null && value != DBNull.Value)
                    {

                        value = value.ToString().ClearText();
                    }
                }

                string columName = sqlCommandParam.Property.Name;

                switch (sqlCommandParam.Operator)
                {
                    case Operator.ESIT:
                        if (GetTypeName(sqlCommandParam.Property.PropertyType) == "DateTime")
                        {
                            sqlCommandParam.CommandText += Environment.NewLine +
                            "AND " + sqlCommandParam.Prefix + "." + columName + "=TO_DATE(:" + columName + ",'DD.MM.YYYY HH24:MI:SS')";
                        }
                        else
                        {
                            sqlCommandParam.CommandText += Environment.NewLine +
                            "AND " + sqlCommandParam.Prefix + "." + columName + "=:" + columName;
                        }

                        break;
                    case Operator.ESITDEGIL:
                        sqlCommandParam.CommandText += Environment.NewLine +
                       "AND " + sqlCommandParam.Prefix + "." + columName + "!=:" + columName;
                        break;
                    case Operator.ICINDE:
                        sqlCommandParam.CommandText += Environment.NewLine +
                        "AND " + sqlCommandParam.Prefix + "." + columName + " IN (SELECT COLUMN_VALUE FROM TABLE(SBS_TAB.STRING_TO_TAB(NLS_UPPER(:" + columName + ",'NLS_SORT=Xturkish'))))";
                        break;
                    case Operator.BUYUK:
                        break;
                    case Operator.KUCUK:
                        break;
                    case Operator.BUYUKESIT:
                        break;
                    case Operator.KUCUKESIT:
                        break;
                    case Operator.LIKE:
                        sqlCommandParam.CommandText += Environment.NewLine +
                        "AND NLS_UPPER(" + sqlCommandParam.Prefix + "." + columName + "," +
                        "'NLS_SORT=Xturkish') LIKE '%' || NLS_UPPER(:" + columName + ", 'NLS_SORT=Xturkish') || '%'";
                        break;
                    default:
                        break;
                }

                if (sqlCommandParam.Value != null)
                {
                    sqlCommandParam.OraParam.Add(new OracleParameter
                    {
                        Value = sqlCommandParam.Value,
                        ParameterName = sqlCommandParam.Property.Name,
                        Direction = ParameterDirection.Input,
                        OracleDbType = sqlCommandParam.Operator == Operator.ICINDE ? OracleDbType.Varchar2 : GetDbType(sqlCommandParam.Property)
                    });
                }
                else
                {
                    sqlCommandParam.OraParam.Add(new OracleParameter
                    {
                        Value = value,
                        ParameterName = columName,
                        Direction = ParameterDirection.Input,
                        OracleDbType = sqlCommandParam.Operator == Operator.ICINDE ? OracleDbType.Varchar2 : GetDbType(sqlCommandParam.Property)
                    });
                }
            }
            return sqlCommandParam.CommandText;
        }
    }
}
