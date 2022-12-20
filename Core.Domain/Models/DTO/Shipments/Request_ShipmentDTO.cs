using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Shipment
{
    [DisplayName("ShipmentInfo")]
    public class Request_ShipmentDTO
    {
        [Required(ErrorMessageResourceName = "RequestIDRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "RequestIDNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string RequestId { get; set; }
        [Required(ErrorMessageResourceName = "ShipmentNumberRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ShipmentNumber { get; set; }
        [Required]
        public ShipmentAddressDTO ShipmentAddress { get; set; }
    }
}