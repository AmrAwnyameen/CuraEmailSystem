using Core.Domain.Models.DTO.Farm;
using Core.Domain.Models.DTO.File;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.UpdateRequests
{

    [DisplayName("UpdateOrchards")]
    public class UpdatedOrchardsDTO
    {
        [Required(ErrorMessageResourceName = "serviceCodeRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "ServiceCodeInvalid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? ServiceCode { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "RequestNotValidRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Required(ErrorMessageResourceName = "RequestIDRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string RequestID { get; set; }
        public List<AttachmentDTO> Attachments  { get; set; }

        public OrchardDTO FarmInformation { get; set; }

    }
}