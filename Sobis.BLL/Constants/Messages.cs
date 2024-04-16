using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.BLL.Constants
{
    public class Messages : IMessages
    {
        public static string DbError = "Veritabanı oluştu. İşlem Gerçekleştirilemedi.";
        public static string AppError = "Uygulama hatası oluştu. İşlem Gerçekleştirilemedi.";

        public static string NullIdError = $"Id boş geçilmemelidir.";

        public static string MultipleRecordFound = $"Aynı kayıt sistemde mevcut.";

        public static string NotFoundError = $"Kayıt Bulunamadı.";
    }
}
