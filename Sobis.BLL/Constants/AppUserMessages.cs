using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.BLL.Constants
{
    public static class AppUserMessages
    {
        public static string NullIdError = $"Id boş geçilmemelidir.";
        public static string TokeCreated = $"Token Oluşturuldu..";
        public static string EmptyClaim = $"Kullanıcıya atanmış herhangi bir yetki bulunamadı.";
        public static string UserNotFound = $"Kullanıcı Adı Bulunamadı!";
        public static string WrogPassword = $"Parola Hatalı!";
    }
}
