using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Farm
{
    [DisplayName("GetMyByIDResponse")]
    public class FarmResult
    {
      
        public List<FarmInfo> FarmsInformation { get; set; }
        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }

        [Required]
        [DefaultValue("0")]
        public string RequestID { get; set; }

    }
    [DisplayName("FarmInformation")]
    public class FarmInfo
    {
        [Required]
        public string FarmGovernorate { get; set; }
        [Required]
        public string FarmCity { get; set; }
      
        public int FarmArea { get; set; }
       
        public string FarmActivityType { get; set; }
        [Required]
        public string FarmAddress { get; set; }
        [Required]
        public string FarmPropertyType { get; set; }
        [Range(0, int.MaxValue, ErrorMessageResourceName = "numberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int FarmAcre { get; set; }
        [Range(0, int.MaxValue, ErrorMessageResourceName = "numberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int FarmCarat { get; set; }
        [Range(0, int.MaxValue, ErrorMessageResourceName = "numberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int FarmShare { get; set; }
      
        public string FarmEasternBorder { get; set; }
       
        public string FarmNorthernBorder { get; set; }
      
        public string FarmWesternBorder { get; set; }
       
        public string FarmSouthernBorder { get; set; }

        public int? GreenHouseNumber { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "numberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
     
        public int FarmID { get; set; }

    }
}