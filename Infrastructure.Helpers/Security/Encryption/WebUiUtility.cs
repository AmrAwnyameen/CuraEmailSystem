using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web;
using System.Web.Routing;
using System.IO;

namespace Infrastructure.Helpers.Security
{
    public static class WebUiUtility
    {
        public static string Encrypt(string plainText)
        {
            string key = AESEncryptionHelper.EncryptStringTriple("PEN-EGPassport-Security-Key", "IBS");
            return AESEncryptionHelper.EncryptStringAES(plainText, key);
            //return   EncryptionHelper.EncryptWithOutSpectialCharacter(plainText);

        }

        public static string Decrypt(string cipherText)
        {
            string key = AESEncryptionHelper.EncryptStringTriple("PEN-EGPassport-Security-Key", "IBS");
            return AESEncryptionHelper.DecryptStringAES(cipherText, key);
            //return EncryptionHelper.DecryptWithOutSpectialCharacter(cipherText);

        }

        public static string EncryptAdminUser(string plainText)
        {
            return EncryptionHelper.EncryptWithOutSpectialCharacter(plainText);
            //return   EncryptionHelper.EncryptWithOutSpectialCharacter(plainText);

        }

        public static string DecryptAdminUser(string cipherText)
        {
            return EncryptionHelper.DecryptWithOutSpectialCharacter(cipherText);

        }

        public static string EncryptPass(string plainText)
        {
            return EncryptionHelper.Encrypt(plainText);
        }

        public static string DecryptPass(string cipherText)
        {
            return EncryptionHelper.Decrypt(cipherText);
        }

        public static bool IsNumeric(this string text)
        {
            double test;
            return double.TryParse(text, out test);
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }



        private static void DecomposeUrl(string fullUrl, out string areaName, out string controllerName, out string actionName)
        {
            var questionMarkIndex = fullUrl.IndexOf('?');
            string queryString = null;
            string url = fullUrl;
            actionName = ""; controllerName = ""; areaName = "";
            if (questionMarkIndex != -1) // There is a QueryString
            {
                url = fullUrl.Substring(0, questionMarkIndex);
                queryString = fullUrl.Substring(questionMarkIndex + 1);
            }
            if (url.EndsWith("/"))
                url = url.Remove(url.Length - 1);
            string[] urlArr = url.Split('/');
            if (urlArr.Length >= 1) actionName = urlArr[urlArr.Length - 1];
            if (urlArr.Length >= 2) controllerName = urlArr[urlArr.Length - 2];
            if (urlArr.Length >= 3) areaName = urlArr[urlArr.Length - 3];



            return;

            // Arranges
            var request = new HttpRequest(null, url, queryString);
            var response = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(request, response);

            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            // Extract the data    
            var values = routeData.Values;
            controllerName = values["controller"].ToString();
            actionName = values["action"].ToString();
            areaName = "";// values["area"].ToString();
        }


    }
}
