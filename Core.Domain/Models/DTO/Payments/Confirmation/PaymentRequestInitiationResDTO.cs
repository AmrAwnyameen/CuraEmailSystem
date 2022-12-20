using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Domain.Models.DTO.Payments.Confirmation
{
    [DisplayName("PaymentRequestInitiationRes")]
    public class PaymentRequestInitiationResDTO
    {
        [Required(ErrorMessageResourceName = "PaymentRequestTotalAmount", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, 9999999999999999.99, ErrorMessageResourceName = "PaymentRequestTotalNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public decimal? PaymentRequestTotalAmount { get; set; }
        [Required(ErrorMessageResourceName = "CollectionFeesAmount", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, 9999999999999999.99, ErrorMessageResourceName = "CollectionFeesAmountNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public decimal? CollectionFeesAmount { get; set; }
    }
}