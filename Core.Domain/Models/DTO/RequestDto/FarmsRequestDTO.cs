using Core.Domain.Models.DTO.Company;
using Core.Domain.Models.DTO.Farm;
using Core.Domain.Models.DTO.Shipment;
using Core.Domain.Models.DTO.Users;
using Infrastructure.Helpers.CustomAttributes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.RequestDto
{
    [DisplayName("SubmitFarmLicenseRequest")]
    public class FarmsRequestDTO
    {
        [Required(ErrorMessageResourceName = "serviceCodeRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public UserInfoDTO CommonRequestAttributes { get; set; }


        public CompanyDTO CommonRequestCompanyAttributes { get; set; }
        [Required(ErrorMessageResourceName = "FarmGovernorate", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public FarmDTO FarmInformation { get; set; }

        public ShipmentAddressDTO ShipmentAddress { get; set; }

        public int? RequesterType { get; set; }
        public int? Character { get; set; }
        public string AuthorizationNumber { get; set; }
        public string Letter { get; set; }
        [JsonConverter(typeof(EmptyToNullConverter))]
        [StringLength(4, ErrorMessageResourceName = "YearnotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses), MinimumLength = 4)]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "YearnotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string Year { get; set; }
        public string DocumentationOffice { get; set; }
        public string CommericalRegister { get; set; }
        public string TransactionCategoryDesc { get; set; }
        public string CompanyName { get; set; }
        [Required(ErrorMessageResourceName = "DeliveryMethodRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, 1, ErrorMessageResourceName = "DeliveryMethodNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? DeliveryMethod { get; set; }
        public string Office { get; set; }
    }
}