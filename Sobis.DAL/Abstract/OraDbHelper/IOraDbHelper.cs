using Oracle.ManagedDataAccess.Client;
using Sobis.Core.Entities.Abstract;
using Sobis.Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Data;

namespace Sobis.DAL.Abstract.OraDbHelper
{
    public interface IOraDbHelper : IEntity
    {
        IResult ExecuteSql(string SqlCommand, IEnumerable<OracleParameter> Params);
        IResult ExecuteSql(string SqlCommand, IEnumerable<OracleParameter> Params, string retVal);
        IDataResult<System.Data.DataRow> GetDataRow(string SqlCommand, IEnumerable<OracleParameter> Params);
        IDataResult<DataRow> GetDataCell<DataRow>(string SqlCommand);
        IDataResult<IEnumerable<dynamic>> GetDynamicRecord(string SqlCommand, IEnumerable<object> Params=null);
        string AddSql(string SqlCommand, string value);
        DataTable GetDataTableFromReader(IDataReader DataReader);
        DataTable GetDataTable(string SqlCommand, IEnumerable<OracleParameter> Params);
        IDataResult<DataRow> GetDataTableRow(string SqlCommand, IEnumerable<OracleParameter> Params);
        public List<T> SqlRecordBySql<T>(string SqlCommand, IEnumerable<OracleParameter> Params = null);
    }
}
