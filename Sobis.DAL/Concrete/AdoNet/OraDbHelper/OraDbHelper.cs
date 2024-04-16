using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Core.Utilities.Results.Concrete;
using Sobis.DAL.Abstract.OraDbHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;

namespace Sobis.DAL.Concrete.AdoNet.OraDbHelper
{
    public class OraDbHelper : IOraDbHelper
    {
        private readonly OracleConnection oraCon;
        private readonly ILogger<OraDbHelper> _logger;
        private readonly IConfiguration _configuration;
        public OraDbHelper(ILogger<OraDbHelper> logger, IConfiguration configuration) : this("SbsCnnString", logger, configuration)
        {

        }
        public OraDbHelper(string connectionStringName, ILogger<OraDbHelper> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            string connectionString = _configuration["ConnectionStrings:SbsOraConnection"];
            //"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.25.10.40)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=ORCL)));User Id=SOBIS;Password=1;"; //ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            oraCon ??= new OracleConnection(connectionString);
        }

        public string AddSql(string SqlCommand, string value)
        {
            var retVal = SqlCommand;
            if (!String.IsNullOrEmpty(value))
            {
                retVal += Environment.NewLine + value;
            }
            return retVal;
        }

        public OracleConnection OraBaglan()
        {
            //OracleConnection conn = new OracleConnection();
            try
            {
                if (oraCon.State != ConnectionState.Open)
                {
                    oraCon.Open();
                }
            }
            catch (Exception)
            {
                //throw new Exception("HATA: Veri Tabanına Bağlanamadı." + " " + ex.Message);
                return new OracleConnection(_configuration["ConnectionStrings:SbsOraConnection"]);
            }
            return oraCon;
        }
        public IResult ExecuteSql(string SqlCommand, IEnumerable<OracleParameter> Params)
        {
            if (!string.IsNullOrEmpty(SqlCommand))
            {
                using (OracleConnection oraCon = OraBaglan())
                {
                    if (oraCon.State != ConnectionState.Open)
                    {
                        oraCon.Open();
                    }
                    using (OracleCommand oraCmd = new OracleCommand())
                    {
                        oraCmd.Connection = oraCon;
                        oraCmd.Parameters.Clear();
                        oraCmd.CommandText = SqlCommand;
                        oraCmd.BindByName = true;
                        Dictionary<string, object> LogParameters = new Dictionary<string, object>();

                        foreach (OracleParameter item in Params)
                        {
                            _ = oraCmd.Parameters.Add(item);
                            LogParameters.Add(item.ParameterName + " - " + item.DbType, item.Value);
                        }

                        _logger.LogInformation(oraCmd.CommandText + Environment.NewLine + LogParameters);
                        int result = oraCmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return new Result(true);
                        }
                    }
                }
            }
            else
            {
                return new Result(false);
            }
            return new Result(true);
        }

        public IResult ExecuteSql(string SqlCommand, IEnumerable<OracleParameter> Params, string retVal)
        {
            string commandText = SqlCommand;

            commandText += Environment.NewLine + "RETURNING " + retVal + " INTO :P_SONUC";

            using (OracleConnection oraCon = OraBaglan())
            {
                if (oraCon.State != ConnectionState.Open)
                {
                    oraCon.Open();
                }
                using (OracleCommand oraCmd = new OracleCommand())
                {
                    oraCmd.Connection = oraCon;
                    oraCmd.Parameters.Clear();
                    oraCmd.CommandText = commandText;
                    oraCmd.BindByName = true;
                    Dictionary<string, object> LogParameters = new Dictionary<string, object>();

                    foreach (OracleParameter item in Params)
                    {
                        _ = oraCmd.Parameters.Add(item);
                        LogParameters.Add(item.ParameterName, item.Value);
                    }
                    oraCmd.Parameters.Add("P_SONUC", OracleDbType.Decimal, ParameterDirection.Output);

                    _logger.LogInformation(oraCmd.CommandText + Environment.NewLine + LogParameters);

                    int result = oraCmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return new Result(true, oraCmd.Parameters["P_SONUC"].Value.ToString());
                    }
                }
            }
            return new Result(false);
        }

        public IDataResult<T> GetDataCell<T>(string SqlCommand)
        {
            using (OracleConnection oraCon = OraBaglan())
            {
                if (oraCon.State != ConnectionState.Open)
                {
                    oraCon.Open();
                }

                using (OracleCommand oraCmd = oraCon.CreateCommand())
                {
                    oraCmd.Parameters.Clear();
                    oraCmd.CommandText = SqlCommand;

                    using (OracleDataReader rdr = oraCmd.ExecuteReader())
                    {

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!rdr.IsDBNull(i))
                            {
                                return new DataResult<T>(true, rdr.GetFieldValue<T>(rdr.GetOrdinal((string)rdr[0])));
                            }
                        }
                    }
                    _logger.LogInformation(oraCmd.CommandText + Environment.NewLine);
                }
            }
            return new DataResult<T>(false);
        }

        public IDataResult<T> GetList<T>(string SqlCommand, IEnumerable<OracleParameter> Params = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<DataRow> GetDataRow(string SqlCommand, IEnumerable<OracleParameter> Params)
        {
            var result = GetDataTable(SqlCommand, Params);
            return (result.Rows.Count == 0 ? new DataResult<DataRow>(false) : new DataResult<DataRow>(true, result.Rows[0]));
        }

        public DataTable GetDataTable(string SqlCommand, IEnumerable<OracleParameter> Params)
        {
            DataTable resultTable = null;

            using (OracleConnection oraCon = OraBaglan())
            {
                if (oraCon.State != ConnectionState.Open)
                {
                    oraCon.Open();
                }
                using (OracleCommand oraCmd = oraCon.CreateCommand())
                {
                    oraCmd.Parameters.Clear();
                    oraCmd.CommandText = SqlCommand;
                    Dictionary<string, object> LogParameters = new Dictionary<string, object>();
                    if (Params != null)
                    {
                        foreach (OracleParameter item in Params)
                        {
                            oraCmd.Parameters.Add(item);
                            LogParameters.Add(item.DbType + " - " + item.ParameterName, item.Value);
                        }
                    }
                    //logger.SbsLogInfo(GetType(), oraCmd.CommandText, LogParameters);
                    _logger.LogInformation(oraCmd.CommandText + Environment.NewLine + LogParameters);
                    using (IDataReader rdr = oraCmd.ExecuteReader())
                    {
                        resultTable = GetDataTableFromReader(rdr);
                    }
                }
            }

            return resultTable;
        }

        public DataTable GetDataTableFromReader(IDataReader DataReader)
        {
            DataTable schemaTable = DataReader.GetSchemaTable();
            DataTable resultTable = new DataTable();

            foreach (DataRow dataRow in schemaTable.Rows)
            {
                DataColumn dataColumn = new DataColumn
                {
                    ColumnName = dataRow["ColumnName"].ToString(),
                    DataType = Type.GetType(dataRow["DataType"].ToString()),
                    ReadOnly = (bool)dataRow["IsReadOnly"]
                };

                resultTable.Columns.Add(dataColumn);
            }

            object[] aData = new object[resultTable.Columns.Count];

            while (DataReader.Read())
            {
                DataReader.GetValues(aData);
                resultTable.Rows.Add(aData);
            }
            return resultTable;
        }

        public IDataResult<DataRow> GetDataTableRow(string SqlCommand, IEnumerable<OracleParameter> Params)
        {
            throw new NotImplementedException();
        }

        public List<T> SqlRecordBySql<T>(string SqlCommand, IEnumerable<OracleParameter> Params = null)
        {
            throw new NotImplementedException();
        }
        public IDataResult<IEnumerable<dynamic>> GetDynamicRecord(string SqlCommand, IEnumerable<object> Params = null)
        {
            IList<dynamic> lists = new List<dynamic>();
            StringBuilder commandText = new StringBuilder(SqlCommand);
            string logParameter = string.Empty;
            try
            {
                using (OracleConnection oraCon = OraBaglan())
                {
                    if (oraCon.State != ConnectionState.Open)
                    {
                        oraCon.Open();
                    }

                    using (OracleCommand oraCmd = oraCon.CreateCommand())
                    {
                        oraCmd.Parameters.Clear();
                        Dictionary<string, object> LogParameters = new Dictionary<string, object>();
                        foreach (OracleParameter item in Params)
                        {
                            _ = oraCmd.Parameters.Add(item);
                            LogParameters.Add(item.DbType + " - " + item.ParameterName, item.Value);
                        }
                        oraCmd.CommandText = commandText.ToString();
                        logParameter = string.Join(Environment.NewLine, LogParameters);
                        _logger.LogInformation(oraCmd.CommandText + Environment.NewLine + logParameter);
                        using (OracleDataReader rdr = oraCmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                {
                                    IDictionary<string, object> row = new ExpandoObject();
                                    for (int fieldCount = 0; fieldCount < rdr.FieldCount; fieldCount++)
                                    {
                                        row.Add(rdr.GetName(fieldCount), rdr[fieldCount]);
                                    }
                                    lists.Add(row);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new ErrorDataResult<IEnumerable<dynamic>>();
            }
            return new SuccessDataResult<IEnumerable<dynamic>>(lists);
        }

        public List<T> SqlRecordBySql<T>(string SqlCommand, IEnumerable<object> Params = null)
        {
            List<T> lists = new List<T>();
            IList<OracleParameter> OraParam = null;
            if (Params != null)
            {
                OraParam = (IList<OracleParameter>)Params;
            }

            try
            {
                if (!string.IsNullOrEmpty(SqlCommand))
                {
                    using (OracleConnection oraCon = OraBaglan())
                    {
                        if (oraCon.State != ConnectionState.Open)
                        {
                            oraCon.Open();
                        }

                        using (OracleCommand oraCmd = new OracleCommand())
                        {
                            oraCmd.Connection = oraCon;
                            oraCmd.Parameters.Clear();
                            oraCmd.CommandText = SqlCommand;
                            Dictionary<string, object> LogParameters = new Dictionary<string, object>();
                            if (Params != null)
                            {
                                foreach (var item in OraParam)
                                {
                                    _ = oraCmd.Parameters.Add(item);
                                    LogParameters.Add(item.ParameterName, item.Value);
                                }
                            }

                            using (OracleDataReader rdr = oraCmd.ExecuteReader())
                            {
                                var list = new List<T>();
                                T obj = default;
                                while (rdr.Read())
                                {
                                    obj = Activator.CreateInstance<T>();

                                    var typeProperties = typeof(T).GetProperties();

                                    foreach (var property in typeProperties)
                                    {
                                        int ordinal = -1;
                                        try
                                        {
                                            ordinal = rdr.GetOrdinal(property.Name);
                                        }
                                        catch (Exception)
                                        {
                                            ordinal = -1;
                                            property.SetValue(obj, null, null);
                                        }

                                        if (ordinal > -1)
                                        {
                                            if (!rdr.IsDBNull(ordinal))
                                            {
                                                property.SetValue(obj, rdr[property.Name], null);
                                            }
                                        }
                                    }

                                    list.Add(obj);
                                }

                                lists = list;
                            }
                            _logger.LogInformation(oraCmd.CommandText + Environment.NewLine + LogParameters);
                        }
                    }
                }
                else
                {
                    return default;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return default;
            }
            return lists;
        }

    }
}
