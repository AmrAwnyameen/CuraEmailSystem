using Core.Domain.Models.DTO.File;
using Infrastructure.Helpers.CustomAttributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.Complaint
{

    [DisplayName("SubmitComplaintForDamage")]
    public class ComplaintDTO
    {
        [Required(ErrorMessageResourceName = "serviceCodeRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [Range(0, int.MaxValue, ErrorMessageResourceName = "ServiceCodeInvalid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public int? ServiceCode { get; set; }
        [Required(ErrorMessageResourceName = "ApplicantName", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ApplicantName { get; set; }
        [Required(ErrorMessageResourceName = "NationalID", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]{14,14}$", ErrorMessageResourceName = "NationalIdLenght", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string NationalID { get; set; }
        [Required(ErrorMessageResourceName = "PhoneNumber", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^01[0-2,5]{1}[0-9]{8}$", ErrorMessageResourceName = "PhoneLenght", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessageResourceName = "ApplicantAddress", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ApplicantAddress { get; set; }
        [JsonConverter(typeof(EmptyToNullConverter))]
        [EmailAddress(ErrorMessageResourceName = "EmailNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ApplicantEmail { get; set; }

        [Required(ErrorMessageResourceName = "ApplicantGovernorate", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]{3}$", ErrorMessageResourceName = "ApplicantGovernorateNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ApplicantGovernorate { get; set; }
        public List<AttachmentDTO> Attachments { get; set; }

        [Required(ErrorMessageResourceName = "ComplainedPartyIsRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ComplainedParty { get; set; }
        [Required(ErrorMessageResourceName = "TypeOfDamageIsRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string TypeOfDamage { get; set; }
        [Required(ErrorMessageResourceName = "ComplaintSubjectIsRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string ComplaintSubject { get; set; }
    }
}