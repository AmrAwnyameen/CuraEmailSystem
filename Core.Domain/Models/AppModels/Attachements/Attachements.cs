using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Domain.Models.AppModels.Attachements
{
   public class Attachements
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Attachements_AttachmentCode { get; set; }
        [Required]
        public string Attachements_AttachmentName { get; set; }
        [Required]
        public HttpPostedFileBase Attachements_Attachment { get; set; }
    }
}
