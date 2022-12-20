using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Domain.Models.DTO.Lookups
{
    [DisplayName("GetLookUps")]
    public class GetLookUpDTO
    {
        [Required(ErrorMessageResourceName = "CodeRequiredLookup", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "CodeInvalidLookup", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? Code { get; set; }
        [Range(0, int.MaxValue, ErrorMessageResourceName = "StParentCodeNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? StParentCode { get; set; }
    }
}