using Core.Domain.Models.DTO.Citizen;
using System.Collections.Generic;

namespace Core.Domain.Models.DTO.Notification
{
    public class details
    {
        public string Message { get; set; }
        public List<CitizenDocumentsInquieryDTO>  Attachements { get; set; }
    }
}
