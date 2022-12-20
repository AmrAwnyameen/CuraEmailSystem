using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Citizen
{
    [DisplayName("InquireAttchments")]
    public class CitizenDocumentsInquieryDTO
    {
        [Required]
        public int AttachmentCode { get; set; }
        [Required]
        public string AttachmentName { get; set; }
    }
}