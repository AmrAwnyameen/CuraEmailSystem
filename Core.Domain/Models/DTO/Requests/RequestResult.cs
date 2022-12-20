using Core.Domain.Models.DTO.Citizen;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Requests
{
    [DisplayName("InquireRequestStatusResponse")]
    public class RequestResult
    {   
        [Required]
        public string RequestStatus { get; set; }
        [Required]
        public string TimeStamp { get; set; }
        [Required]
       

        public string Comment { get; set; }

        public List<CitizenDocumentsInquieryDTO> Attachements { get; set; }

        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }
    }
}