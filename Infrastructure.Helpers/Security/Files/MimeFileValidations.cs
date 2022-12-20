using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Helpers.Security
{
    public static class MimeFileValidations
    {
        public static bool IsValidContetntType(HttpPostedFileBase file)
        {
            var mimContentType = file.ContentType;
            if (mimContentType.Equals("application/octet-stream") || mimContentType.Equals("application/x-msdownload"))
            {
                return false;
            }
            if (file.FileName.Contains(".bat") || file.FileName.Contains(".exe"))
            {
                return false;
            }
            return true;
        }
    }
}
