using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Domain.Models.DTO.Requests
{
    [DisplayName("CancelRequestResponse")]
    public class CancelRequestResult
    {
        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }
    }
}