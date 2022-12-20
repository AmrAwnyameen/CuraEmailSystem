using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Payments.Confirmation
{
    [DisplayName("PaymentConfirmationRequest")]
    public class PaymentConfirmationDTO
    {
        public string SenderRequestNumber { get; set; }
        public string PaymentRequestNumber { get; set; }
        [Required(ErrorMessageResourceName = "CustomerAuthorizationAmountRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "CustomerAuthorizationAmountNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public decimal? CustomerAuthorizationAmount { get; set; }
        public string AuthorizationCode { get; set; }
        [Required(ErrorMessageResourceName = "TransactionNumberRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string TransactionNumber { get; set; }
        public string AuthorizingMechanism { get; set; }
        public string AuthorizingInstitution { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}", ErrorMessageResourceName = "AuthoriztionDateTimeNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string AuthoriztionDateTime { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "ReconciliationDateNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ReconciliationDate { get; set; } 

        public string IsConfirmed { get; set; }

    }

 
}