using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Core.Enums
{
    public enum ResultCode
    {
        Success = 1,
        AppError = 2,
        DbError = 3
    }
    public enum IsActive
    {
        E,
        H
    }
    public enum Operator
    {
        ESIT,
        ICINDE,
        BUYUK,
        KUCUK,
        BUYUKESIT,
        KUCUKESIT,
        LIKE,
        ESITDEGIL
    }
    public enum ProcTypes
    {
        Insert,
        Update,
        Delete,
        Null
    }

    public enum DbType
    {
        Oracle,
        MSSql,
        MySQL,
        Firebird,
        PostgreSql
    }
    public enum Opinion
    {
        Yes,
        No,
        Abstain
    }
    public enum CheckStatus
    {
        Checked,
        Unchecked,
        Abstain
    }

}
