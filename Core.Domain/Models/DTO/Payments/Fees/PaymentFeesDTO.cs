using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Payments.Fees
{
    [DisplayName("GetServiceFees")]
    public class PaymentFeesDTO
    {
        [Required(ErrorMessageResourceName = "RequestIDRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "RequestIDNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string RequestID { get; set; }
     
    }
}