using Core.Domain.Models.DTO.Payments.Fees;
using Core.Domain.Models.DTO.Response;
using Core.Domain.Models.DTO.Shipment;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Payments.PaymentFeesResponse
{
    [DisplayName("FeesResponse")]
    public class FeesResponseDTO : MainResponseResult
    {


        [Required]
        public decimal RequestFees { get; set; }

        [Required]
        public ServiceCategoryFeesDTO PaymentRequestInitiationReq { get; set; }

        public ShipmentAddressDTO ShipmentAddress { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "numberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string DeliveryMethod { get; set; }

    }
}