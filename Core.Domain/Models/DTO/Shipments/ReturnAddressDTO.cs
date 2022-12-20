using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Domain.Models.DTO.Shipment
{
    [DisplayName("ReturnAddress")]
    public class ReturnAddressDTO
    {
        
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int GovernorateCode { get; set; }
    }
}