using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Sobis.Core.Extensions
{
    public static class Controls
    {
        public static string ClearText(this string strVeri)
        {
            try
            {
                strVeri = strVeri.Replace("<", "&lt;");
                strVeri = strVeri.Replace(">", "&gt;");
                strVeri = strVeri.Replace("[", "&#091;");
                strVeri = strVeri.Replace("]", "&#093;");
                strVeri = strVeri.Replace("=", "&#061;");
                strVeri = strVeri.Replace("'", "''");
                strVeri = strVeri.Replace("select", "sel&#101;ct");
                strVeri = strVeri.Replace("join", "jo&#105;n");
                strVeri = strVeri.Replace("union", "un&#105;on");
                strVeri = strVeri.Replace("where", "wh&#101;re");
                strVeri = strVeri.Replace("insert", "ins&#101;rt");
                strVeri = strVeri.Replace("delete", "del&#101;te");
                strVeri = strVeri.Replace("update", "up&#100;ate");
                strVeri = strVeri.Replace("like", "lik&#101;");
                strVeri = strVeri.Replace("drop", "dro&#112;");
                strVeri = strVeri.Replace("create", "cr&#101;ate");
                strVeri = strVeri.Replace("modify", "mod&#105;fy");
                strVeri = strVeri.Replace("rename", "ren&#097;me");
                strVeri = strVeri.Replace("alter", "alt&#101;r");
                strVeri = strVeri.Replace("cast", "ca&#115;t");
                strVeri = strVeri.Trim();
                return strVeri;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static decimal? ToDecimal(this object value)
        {
            decimal? refVal;
            if (value != null && value != DBNull.Value)
            {
                try
                {
                    refVal = Convert.ToDecimal(value);
                }
                catch (Exception)
                {
                    //_logger.LogError(ex, ex.Message);
                    refVal = null;
                }

            }
            else
            {
                refVal = null;
            }

            return refVal;
        }

        public static string ToSbsString(this object value)
        {
            string refVal = null;
            if (value != null && value != DBNull.Value)
            {
                try
                {
                    refVal = value.ToString();
                }
                catch (Exception)
                {
                    //ExceptionUtility.LogException(ex);
                    refVal = null;
                }
            }

            return refVal;
        }
        public static int? ToInt(this object value)
        {
            int? refVal;
            if (value != null && value != DBNull.Value)
            {
                try
                {
                    refVal = Convert.ToInt32(value);
                }
                catch (Exception)
                {
                    refVal = null;
                }
            }
            else
            {
                refVal = null;
            }

            return refVal;
        }
        public static short? ToShort(this object value)
        {
            short? refVal;
            if (value != null && value != DBNull.Value)
            {
                try
                {
                    refVal = Convert.ToInt16(value);
                }
                catch (Exception)
                {
                    refVal = null;
                }
            }
            else
            {
                refVal = null;
            }

            return refVal;
        }
        public static DateTime? ToDate(this object value)
        {
            DateTime? refVal;
            if (value != null && value != DBNull.Value)
            {

                try
                {
                    refVal = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    //ExceptionUtility.LogException(ex);
                    refVal = null;
                }

            }
            else
            {
                refVal = null;
            }

            return refVal;
        }

    }
}
