using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Requests
{
    [DisplayName("CancelReques")]
    public class CancelRequestDTO
    {
        [Required(ErrorMessageResourceName = "RequestIDRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "RequestIDNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string RequestID { get; set; }


        public string Reason { get; set; }
    }
}