using Infrastructure.Helpers.CustomAttributes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Company
{
    [DisplayName("CommonRequestCompanyAttributes")]
    public class CompanyDTO
    {
        [Required(ErrorMessageResourceName = "OwnerNameRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string OwnerName { get; set; }
        [Required(ErrorMessageResourceName = "RequestPartyNameValidation", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string RequestPartyName { get; set; }
        [Required(ErrorMessageResourceName = "DetailedAddressValidations", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string DetailedAddress { get; set; }
        [Required(ErrorMessageResourceName = "ActivityTypeValidations", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ActivityType { get; set; }
        [Required(ErrorMessageResourceName = "CommercialRegistrationNoValidations", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string CommercialRegistrationNo { get; set; }
        [JsonConverter(typeof(EmptyToNullConverter))]
        [EmailAddress(ErrorMessageResourceName = "RequestPartyEmailNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string RequestPartyEmail { get; set; }
    }
}