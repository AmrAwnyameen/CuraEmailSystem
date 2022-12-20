using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Domain.Models.DTO.Shipment
{
    [DisplayName("ShipmentAddress")]
    public class ShipmentAddressDTO
    {
        [Required(ErrorMessageResourceName = "FullNameShipmment", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FullName { get; set; }
        [Required(ErrorMessageResourceName = "PhoneNumber", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^01[0-2,5]{1}[0-9]{8}$", ErrorMessageResourceName = "ShipmenPhoneNumberPhoneLenght", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessageResourceName = "AddressShipmment", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string Address { get; set; }
        [Required(ErrorMessageResourceName = "GovernorateCodeShipmment", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "GovernorateCodeNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? GovernorateCode { get; set; }
    }
}