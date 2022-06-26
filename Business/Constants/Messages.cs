using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Success = "Başarılı";
        public static string Error = "Başarısız";

        public static string CarCountOfBrandError = "Aynı markadan sadece 10 ürün olabilir";

        public static string CheckIfSameCarNameExist = "Bu isimde bir ürün zaten mecvut";

        public static string AuthorizationDenied = "Yetkiniz Yok";
    }
}
