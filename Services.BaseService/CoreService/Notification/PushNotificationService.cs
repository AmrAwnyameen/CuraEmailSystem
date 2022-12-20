using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.Logging;
using Core.Domain.Models.DTO.Citizen;
using Core.Domain.Models.DTO.Notification;
using Core.Domain.Models.DTO.Response;
using Elmah;
using Infrastructure.Helpers.Enums;
using Infrastructure.Helpers.Token;
using Infrastructure.Resources.Validations.Arabic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services.InterFaces.ICoreService.ICitizen;
using Services.InterFaces.ICoreService.ICitizenDocumntDeatils;
using Services.InterFaces.ICoreService.IPushNotification;
using Services.InterFaces.ICoreService.IRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Notification
{
    public class PushNotificationService : AppService<GovTalkMessage>, IPushNotificationService
    {
        #region Container
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICitizenReplyService _citizenReplyService;
        private readonly ICitizenDocumntDeatilsService _citizenDocumntDeatilsService;
        private readonly IGGHeader _header;
        #endregion

        #region Ctor
        public PushNotificationService(IUnitOfWork unitOfWork, IGGHeader gGHeader, ICitizenReplyService citizenReplyService, ICitizenDocumntDeatilsService citizenDocumntDeatilsService) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _header = gGHeader;
            _citizenReplyService = citizenReplyService;
            _citizenDocumntDeatilsService = citizenDocumntDeatilsService;
        }

        #endregion

        #region services

        public async Task<List<NotificationsResponseResult>> PushNotification(List<requests> requests)
        {
            try
            {
                var notificationsResponses = new List<NotificationsResponseResult>();
                using (var httpClient = new HttpClient())
                {
                    var tokenResponse = await GeneratePortlaToken();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenResponse.token);
                    foreach (var request in requests)
                    {
                        if (Enum.IsDefined(typeof(ValidtionStatusRequiredAttachments), (int)request.REQ_STATUS))
                        {
                            var response = await PostNotificationRequest(request, httpClient);
                            AddNotificationsResponses(await response.Content.ReadAsStringAsync(), notificationsResponses, request);
                        }
                        else
                        {
                            var response = await PostNotificationRequestWithoutAttchments(request, httpClient);
                            AddNotificationsResponses(await response.Content.ReadAsStringAsync(), notificationsResponses, request);
                        }

                    }
                    return notificationsResponses;

                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }


        }

        private async Task<PortlaToken> GeneratePortlaToken()
        {
            try
            {
                await CertificateValidationCallback();
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(new PortalUser() { Username = Ar_Responses.PortlaUserName, Password = Ar_Responses.PortlaPassword });
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var portlaHost = Ar_Responses.PortlaLoginHost;
                    var request = await httpClient.PostAsync(portlaHost, data);
                    return request.Content.ReadAsAsync<PortlaToken>().Result;
                }
            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }
        }

        public async Task CertificateValidationCallback()
        {

            ServicePointManager.ServerCertificateValidationCallback = new
            RemoteCertificateValidationCallback
            (
                delegate { return true; }
            );


        }

        private GovTalkMessageNotification BindGovTalkMessage(requests request)
        {
            try
            {
                var requetsBody = new GovTalkMessageNotification();
                requetsBody.GovTalkMessage.Body.Message.Data.Query.requestId = _header?.FirstOrDefault(s => s.RequestId == request.corr_id)?.channelRequestId;
                requetsBody.GovTalkMessage.Body.Message.Data.Query.status = request.REQ_STATUS.ToString();
                requetsBody.GovTalkMessage.Body.Message.Data.Query.serviceSlug = _header?.FirstOrDefault(s => s.RequestId == request.corr_id)?.ServiceSlug;
                requetsBody.GovTalkMessage.Body.Message.Data.Query.message = request.citizen_reply_details1 != null && !string.IsNullOrEmpty(request.citizen_reply_details1.required_comment) ? request.citizen_reply_details1.required_comment : request.sysl_request_status.description;
                requetsBody.GovTalkMessage.Body.Message.Data.Query.AttchmentsDetials.Message = requetsBody.GovTalkMessage.Body.Message.Data.Query.message;

                if (Enum.IsDefined(typeof(ValidtionStatusRequiredAttachments), (int)request.REQ_STATUS))
                {
                    var checkCitizenDocumentsExist = FindCitizenDocuments(request);
                    requetsBody.GovTalkMessage.Body.Message.Data.Query.AttchmentsDetials.Attachements =
                       checkCitizenDocumentsExist.Item1 == true && checkCitizenDocumentsExist.Item2.Any() ?
                         NotificationAttachmentsDetails(request, checkCitizenDocumentsExist.Item2)
                        : new List<CitizenDocumentsInquieryDTO>();
                }

                return requetsBody;
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }

        }

        private GovTalkMessageNotification BindGovTalkMessageWithoutAtthcments(requests request)
        {
            try
            {
                var requetsBody = new GovTalkMessageNotification();
                requetsBody.GovTalkMessage.Body.Message.Data.Query.requestId = _header?.FirstOrDefault(s => s.RequestId == request.corr_id)?.channelRequestId; ;
                requetsBody.GovTalkMessage.Body.Message.Data.Query.status = request.REQ_STATUS.ToString();
                requetsBody.GovTalkMessage.Body.Message.Data.Query.serviceSlug = _header?.FirstOrDefault(s => s.RequestId == request.corr_id)?.ServiceSlug;
                requetsBody.GovTalkMessage.Body.Message.Data.Query.message = request.citizen_reply_details1 != null && !string.IsNullOrEmpty(request.citizen_reply_details1.required_comment) ? request.citizen_reply_details1.required_comment : request.sysl_request_status.description;
                requetsBody.GovTalkMessage.Body.Message.Data.Query.AttchmentsDetials.Message = requetsBody.GovTalkMessage.Body.Message.Data.Query.message;
                requetsBody.GovTalkMessage.Body.Message.Data.Query.AttchmentsDetials.Attachements = null;
                return requetsBody;
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }

        }

        private List<CitizenDocumentsInquieryDTO> NotificationAttachmentsDetails(requests request, List<citizen_reply_required_documents> citizenReplyDocuments)
        {
            var documents = citizenReplyDocuments != null && citizenReplyDocuments.Any() ? citizenReplyDocuments.
                Select(s =>
                new CitizenDocumentsInquieryDTO { AttachmentCode = (int)s.l_document_type.id, AttachmentName = s.l_document_type.DOCTYPENAME }).ToList() : null;
            return documents;
        }

        private Tuple<bool, List<citizen_reply_required_documents>> FindCitizenDocuments(requests request)
        {
            try
            {
                var citizenReplyService = _citizenReplyService?.FirstOrDefault(s => s.id == request.CITIZEN_REPLY_DETAILS_ID);
                var citizenReplyDocuments = citizenReplyService != null ? _citizenDocumntDeatilsService.Include(s => s.l_document_type).Where(s => s.CITIZEN_REPLY_DETAILS_ID == citizenReplyService.id).ToList() : null;
                if (citizenReplyDocuments != null && citizenReplyDocuments.Any())
                {
                    return new Tuple<bool, List<citizen_reply_required_documents>>(true, citizenReplyDocuments);
                }
                return new Tuple<bool, List<citizen_reply_required_documents>>(false, null);

            }
            catch (Exception ex)
            {

                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }
        }

        private void DeSerializeGovTalkDetails(GovTalkMessageNotification requetsBody)
        {
            requetsBody.GovTalkMessage.Body.Message.Data.Query.details = JsonConvert.SerializeObject(requetsBody.GovTalkMessage.Body.Message.Data.Query.AttchmentsDetials);
        }

        private async Task<HttpResponseMessage> PostNotificationRequest(requests request, HttpClient httpClient)
        {
            try
            {


                var requetsBody = BindGovTalkMessage(request);
                DeSerializeGovTalkDetails(requetsBody);
                var data = new StringContent(JsonConvert.SerializeObject(requetsBody), Encoding.UTF8, "application/json");
                var notificationUrl = Ar_Responses.PortlaNotificationUrl;
                var response = await httpClient.PostAsync(notificationUrl, data);
                LogNotificationRequestResponse(JsonConvert.SerializeObject(requetsBody), response, request);
                return response;

            }
            catch (Exception ex)
            {

                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }
        }

        private async Task<HttpResponseMessage> PostNotificationRequestWithoutAttchments(requests request, HttpClient httpClient)
        {
            try
            {
                var requetsBody = BindGovTalkMessageWithoutAtthcments(request);
                var data = new StringContent(JsonConvert.SerializeObject(requetsBody), Encoding.UTF8, "application/json");
                var notificationUrl = Ar_Responses.PortlaNotificationUrl;
                var response = await httpClient.PostAsync(notificationUrl, data);
                LogNotificationRequestResponse(JsonConvert.SerializeObject(requetsBody), response,request);
                return response;
            }
            catch (Exception ex)
            {

                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }

        }

        private void AddNotificationsResponses(string json, List<NotificationsResponseResult> notificationsResponses, requests request)
        {
            try
            {

                var parsJson = JObject.Parse(json);
                if (parsJson["Message"] == null)
                {
                    HttpResponseMessage response = null;
                    notificationsResponses.Add(new NotificationsResponseResult() { Code = "500", Message = json, Request = request.CORR_NUMBER });
                    LogNotificationRequestResponse(json, response, request);
                    return;
                }

                var ggheaderCode = parsJson["Message"]["Header"]["responseCode"]?.ToString();
                var portlaMessage = parsJson["Message"]["Data"]["Error"] != null ? parsJson["Message"]["Data"]["Error"]["Msg"]?.ToString() :
                    string.Empty;
                var portlaMessageErrorCode = parsJson["Message"]["Data"]["Error"] != null ? parsJson["Message"]["Data"]["Error"]["ErrCode"]?.ToString() :
                    string.Empty;

                if (!CheckIsValidGGPortalResponse(ggheaderCode, portlaMessageErrorCode, portlaMessage))
                    notificationsResponses.Add(new NotificationsResponseResult() { Code = ggheaderCode, PortlaMessageErrorCode = portlaMessageErrorCode, Message = portlaMessage, Request = request.CORR_NUMBER });

                if (CheckIsValidGGPortalResponse(ggheaderCode, portlaMessageErrorCode, portlaMessage))
                    notificationsResponses.Add(new NotificationsResponseResult() { Code = Ar_Responses.Ok, PortlaMessageErrorCode = string.Empty, Message = "Notified", Request = request.CORR_NUMBER });

            }
            catch (Exception ex)
            {

                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }

        }

        private bool CheckIsValidGGPortalResponse(string ggheaderResponseCode, string portlaMessageErrorCode, string portlaMessage )
        {
            if (!string.IsNullOrEmpty(ggheaderResponseCode))
            {
                if ((ggheaderResponseCode != Ar_Responses.Ok) ||
                    (ggheaderResponseCode == Ar_Responses.Ok && !string.IsNullOrEmpty(portlaMessageErrorCode)) ||
                    (ggheaderResponseCode == Ar_Responses.Ok && !string.IsNullOrEmpty(portlaMessage)))
                    return false;

                if (ggheaderResponseCode == Ar_Responses.Ok && string.IsNullOrEmpty(portlaMessageErrorCode) && string.IsNullOrEmpty(portlaMessage))
                    return true;

            }
            return false;
        }
        private void LogNotificationRequestResponse(string serializeRequetsBody, HttpResponseMessage response, requests request)
        {
            try
            {
                _unitOfWork.Repository<NotificationsLogger>().Add(new NotificationsLogger
                {
                    Date = DateTime.Now,
                    Request = serializeRequetsBody,
                    Response = response == null ? serializeRequetsBody : response.Content.ReadAsStringAsync().Result,
                    RequestId= request !=null ? request.CORR_NUMBER : string.Empty
                });
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }

        }

        private void LogNotificationRequest(string serializeRequetsBody, string response)
        {
            try
            {


                if (serializeRequetsBody != null && response != null)
                {
                    _unitOfWork.Repository<RequestsLogger>().Add(new RequestsLogger
                    {
                        Date = DateTime.Now,
                        Request = serializeRequetsBody,
                        Response = response
                    });
                    _unitOfWork.Save();
                }

            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                LogNotificationRequest(ex.InnerException.InnerException.Message, ex.InnerException.Message);
                throw;
            }


        }

        #endregion
    }
}
