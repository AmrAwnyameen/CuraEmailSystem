using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Domain.Models.DTO.Payments.Fees
{
    [DisplayName("PaymentPricingObject")]
    public class ServiceCategoryFeesDTO
    {
       
        public string SenderInvoiceNumber { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        [Required]
        public string ServiceCode { get; set; }
        [Required]
        public List<CategoryFeesSettlementDTO> SettlementAmounts { get; set; }
        [Required]
        public string RequestExpiryDate { get;private set; } = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd HH:mm:ss");
    }
}