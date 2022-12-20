using Core.Domain.Models.DTO.File;
using Core.Domain.Models.DTO.Shipment;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace Core.Domain.Models.DTO.Response
{
    [DisplayName("TokenResponse")]
    public class ResponseResult
    {
        public string RequestID { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string Token { get; set; }
        public string ExpirationDate { get; set; }
    }

    public class ResponseLoginResult
    {
        [ScriptIgnore]
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        [ScriptIgnore]
        public string Token { get; set; }
        [ScriptIgnore]
        public string ExpirationDate { get; set; }
    }

    public class ResponseLoginValidation
    {
        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }

    }
    [DisplayName("SubmitResponse")]
    public class ResponseRequestResult
    {
        [Required]
        public string RequestID { get; set; }
        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }

    }
    [DisplayName("ConfirmResponse")]
    public class MainResponseResult
    {
        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }

    }


    public class NotificationsResponseResult
    {
      
        public string Code { get; set; }
       
        public string Message { get; set; }

        public string Request { get; set; }
        [JsonIgnore]
        public string PortlaMessageErrorCode { get; set; }

    }



    [DisplayName("SubmitComplaintForDamageResponse")]
    public class SubmitComplaintForDamageAPIResponse
    {

        [Required]

        public string RequestID { get; set; }
        [DefaultValue(200)]
        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }
    }

    public class ShipmentInfoResponse
    {

        [Required]
        public int RequireDocumentFromCitizen { get; set; }
        public string DocumentDescription { get; set; }
        [Required]
        public VendorAddressDTO VendorAddress { get; set; }
        [Required]
        public ReturnAddressDTO ReturnAddress { get; set; }
        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }
    }

    public class UpdateDeliveryStatusResponse
    {

        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }
    }
    [DisplayName("LookupValues")]
    public class LookupValuesResponse
    {
        [Required]
        public int Code { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class InquireRequestStatusResponse
    {
        [Required]
        public int ResponseCode { get; set; }
        [Required]
        public string ResponseMessage { get; set; }
        public List<AttachmentDTO> Attachments { get; set; }
    }

}