using Core.Domain.Models.DTO.Payments.Confirmation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Payments.MainConfirmPayment
{
    [DisplayName("ConfirmPayment")]
    public class PaymentConfirmServiceDTO
    {
        [Required(ErrorMessageResourceName = "RequestIDRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "RequestIDNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string RequestID { get; set; }
        [Required]
        public PaymentConfirmationDTO PaymentConfirmationRequest { get; set; }
        [Required]
        public PaymentRequestInitiationResDTO PaymentRequestInitiationRes { get; set; }
        
    }
}