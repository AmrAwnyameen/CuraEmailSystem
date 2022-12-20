using Core.Domain.Models.DTO.Response;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Lookups
{
    public class GetLookUpsResult
    {
        [DefaultValue(1440)]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "numberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int MinutesOfValidity { get; set; }
        [Required]
        public List<LookupValuesResponse> LookupValues { get; set; }
   
        [Required]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "numberOnly", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }
    }
}