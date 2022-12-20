using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace Core.Domain.Models.DTO.File
{
    [DisplayName("Attachments")]
    public class AttachmentDTO
    
    {
        //
        [Required(ErrorMessageResourceName = "AttachmentCodeRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "AttachmentCodeNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? AttachmentCode { get; set; }
        [Required(ErrorMessageResourceName = "AttachmentNameRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string AttachmentName { get; set; }

        [Required(ErrorMessageResourceName = "AttachmentRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [ScriptIgnore]
        public string Attachment { get; set; }


       

    }
}