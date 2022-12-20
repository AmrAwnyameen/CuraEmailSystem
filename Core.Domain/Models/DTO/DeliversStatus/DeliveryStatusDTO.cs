using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models.DTO.DeliversStatus
{
    [DisplayName("UpdateDeliveryStatus")]

    public class DeliveryStatusDTO
    {
        [Required(ErrorMessageResourceName = "RequestIDRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "RequestIDNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string RequestNumber { get; set; }
        [Required(ErrorMessageResourceName = "TimeStampRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression(@"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}", ErrorMessageResourceName = "TimeStampNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string TimeStamp { get; set; }
        [Required(ErrorMessageResourceName = "StatusRequired", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        [RegularExpression("^[0-9]*$", ErrorMessageResourceName = "StatusNotValid", ErrorMessageResourceType = typeof(Infrastructure.Resources.Validations.Arabic.Ar_Responses))]
        public string Status { get; set; }
        public string Message { get; set; }
        public string MetaData { get; set; }
    }
}