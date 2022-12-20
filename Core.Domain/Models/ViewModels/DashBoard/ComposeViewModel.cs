using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Domain.Models.ViewModels.DashBoard
{
    public class ComposeViewModel
    {
        public string ComposeUser { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
    }
}
