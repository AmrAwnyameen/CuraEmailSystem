using Infrastructure.Helpers.CustomAttributes;
using Infrastructure.Helpers.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Farm
{
    [DisplayName("FarmInformationOrchards")]
    public class OrchardDTO
    {
        [Required(ErrorMessageResourceName = "GovernorateOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]{3}$", ErrorMessageResourceName = "FarmGovernorateOrchaNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmGovernorateOrchards { get; set; }
        [Required(ErrorMessageResourceName = "CityOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmCityOrchards { get; set; }
        [Required(ErrorMessageResourceName = "AddressOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmAddressOrchards { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "PropertyTypeNumberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Required(ErrorMessageResourceName = "PropertyTypeOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmPropertyTypeOrchards { get; set; }
        [FarmRequiredSlugs]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "FarmAcreOrchardsNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? FarmAcreOrchards { get; set; }
        [FarmRequiredSlugs]
        [Range(0, 23, ErrorMessageResourceName = "FarmCaratOrchardsNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? FarmCaratOrchards { get; set; }
        [FarmRequiredSlugs]
        [Range(0, 23, ErrorMessageResourceName = "FarmShareOrchardsNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? FarmShareOrchards { get; set; }
        [Required(ErrorMessageResourceName = "EasternBorderOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmEasternBorderOrchards { get; set; }
        [Required(ErrorMessageResourceName = "NorthernBorderOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmNorthernBorderOrchards { get; set; }
        [Required(ErrorMessageResourceName = "WesternBorderOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmWesternBorderOrchards { get; set; }
        [Required(ErrorMessageResourceName = "SouthernBorderOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmSouthernBorderOrchards { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "FarmRequestTypeOrchards", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmRequestTypeOrchards { get; set; }
        public string FarmBuildingID { get; set; }
        [Range(0, int.MaxValue, ErrorMessageResourceName = "FarmIdInvalid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? FarmID { get; set; }
       
        [Range(0, int.MaxValue, ErrorMessageResourceName = "GreenHouseNumberInvalid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [GreenHouseRequiredSlugs]
        public int? GreenHouseNumber { get; set; }


    }
}