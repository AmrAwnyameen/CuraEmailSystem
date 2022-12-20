using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Core.Domain.Models.DTO.Farm
{
    [DisplayName("FarmsInformation")]
    public class FarmDTO
    {
        [Required(ErrorMessageResourceName = "FarmGovernorate", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]{3}$", ErrorMessageResourceName = "FarmGovernorateNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmGovernorate { get; set; }
        [Required(ErrorMessageResourceName = "FarmCity", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmCity { get; set; }
        [Required(ErrorMessageResourceName = "FarmAddress", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmAddress { get; set; }
        [Required(ErrorMessageResourceName = "FarmArea", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "FarmsAreaNumberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? FarmArea { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "ActivityTypeNumberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmActivityType { get; set; }
        [Required(ErrorMessageResourceName = "FarmPropertyType", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmPropertyType { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "RequestTypeNumberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string FarmRequestType { get; set; }
        public string FarmGeographicalLocation { get; set; }
       
        public string FarmBuildingID { get; set; }
        [Range(0, int.MaxValue, ErrorMessageResourceName = "FarmIdInvalid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? FarmID { get; set; }
    }
}