using Sobis.Core.Securitiy.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Entities.StaticVariable
{
    public static class SysVariable
    {
        public static decimal? SMS_PROVIDER_ID { get; set; }
        public static string SMS_USER { get; set; }
        public static string SMS_PASS { get; set; }
        public static string SMS_BASLIK { get; set; }
        public static string FTP_SERVER { get; set; }
        public static string FTP_USER { get; set; }
        public static string FTP_PASS { get; set; }
        public static string FTP_KAYIT_YER { get; set; }
        public static decimal? KURUM_IL { get; set; }
        public static decimal? KURUM_ILCE { get; set; }
        public static decimal? KURUM_ID { get; set; }
        public static string HATA_GOSTER { get; set; }
        public static AccessToken Token { get; set; }

        /*Web Api*/
        public static string WebApiBaseAdres { get; set; }
        public static string WebApiBasePort { get; set; }

        public static Uri? GetBaseAdres()
        {
            return new Uri($"{WebApiBaseAdres}:/{WebApiBasePort ?? "80"}/api");
        }
    }
}
