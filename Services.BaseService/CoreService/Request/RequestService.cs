using Services.InterFaces.ICoreService.IRequest;
using System;
using System.Linq;
using UnitOfWork.Data.IUnitOfWork;
using Core.Domain.Context;
using System.Data.SqlClient;
using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.SiteInfo;
using Infrastructure.Helpers.Enums;
using System.Threading.Tasks;
using System.Collections.Generic;
using Elmah;
using Core.Domain.Models.AppModels.AttachementInfo;
using Core.Domain.Models.AppModels.FarmInfo;
using Core.Domain.Models.DTO.Response;
using Infrastructure.Resources.Validations.Arabic;
using System.Data.Entity;
using Services.InterFaces.ICoreService.IPushNotification;
using Core.Domain.Models.DTO.Farm;

namespace Services.BaseService.CoreService.Request
{
    public class RequestService : AppService<requests>, IRequestService
    {

        #region Container
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGGHeader _gGHeader;
        private readonly IPushNotificationService _pushNotificationService;
        #endregion

        #region Services
        public RequestService(IUnitOfWork unitOfWork, IPushNotificationService pushNotificationService, IGGHeader ggheader) : base(unitOfWork)
        {
            _gGHeader = ggheader;
            _pushNotificationService = pushNotificationService;
            _unitOfWork = unitOfWork;
        }
        public async Task<requests> AddnewRequest(Site user, int? deliveryMethod, int? requesterType)
        {
            var request = new requests()
            {
                CORR_SITE_ID = user.Id,
                CORR_CREATE_DATE = DateTime.Now,
                CORR_CATEGORY_TYPE = Convert.ToDecimal(user.ServiceCode),
                request_owner_Id = user.Id,
                DeliveryMethod = deliveryMethod,
                RequesterType = requesterType,
                F_MIG = (decimal?)MigrationCodes.Migrated,
                F_DESTROY = (decimal?)DestroyedCodes.Destroyed,
            };
            await AddAsync(request);
            return request;
        }
        public async Task<requests> AddApplicationUserRequest(Site user)
        {
            var request = new requests()
            {
                CORR_SITE_ID = user.Id,
                CORR_CREATE_DATE = DateTime.Now,
                REQ_STATUS = (int)CategoryStatus.UnderStudying,
                CORR_CATEGORY_TYPE = Convert.ToDecimal(user.ServiceCode),
                request_owner_Id = user.Id,
                F_MIG = (decimal?)MigrationCodes.Migrated,
                F_DESTROY = (decimal?)DestroyedCodes.Destroyed,
                DeliveryMethod = 0
            };
            await AddAsync(request);
            return request;
        }
        public string GenerateCorrNumber(requests request)
        {
            using (var context = new ApplicationDbContext())
            {
                SqlParameter param1 = new SqlParameter("@CORR_NUMBER", request.corr_id);
                var number = context.Database.SqlQuery<string>("spRequests_Corr_Number @CORR_NUMBER", param1).FirstOrDefault();
                return number;
            };
        }
        public async Task<requests> GetRequestByCorrNumber(decimal requestId)
        {
            return await FirstOrDefaultAsync(x => x.CORR_NUMBER == requestId.ToString());
        }
        public bool CheckStatusForDamageIntgrity(decimal? requestStatusId)
        {
            return requestStatusId != (int)ValidtionStatusRequired.DocumentsRequiredCompleted ? false : true;
        }
        public bool CheckUpdateStatusOrchaIntgrity(decimal? requestStatusId)
        {
            try
            {
                var validRequestStatusId = Convert.ToInt32(requestStatusId);
                return Enum.IsDefined(typeof(ValidtionStatusRequired), validRequestStatusId);
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }
        public async Task<requests> UpdatePaymentRequestStatus(requests request)
        {
            //update  STATUS
            request.REQ_STATUS =
            request.REQ_STATUS ==
            (int)ValidtionPaymentStatus.newRequest ?
            (int)CategoryStatus.UnderStudying :
            request.REQ_STATUS == (int)ValidtionStatusPayment.PaymentRequired ?
            (int)ValidtionStatusPayment.PaymentCompeleted : request.REQ_STATUS;

            //update request 
            request.LastRequestStatusDate = DateTime.Now;
            request.CORR_DELIVERY_DATE = DateTime.Now;
            request.F_MIG = request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : request.F_MIG;

            await UpdateAsync(request);
            return request;
        }
        public bool CheckInqueryValidtionStatus(decimal? requestStatusId)
        {
            try
            {
                var validRequestStatusId = Convert.ToInt32(requestStatusId);
                return Enum.IsDefined(typeof(ValidtionStatusCompeletedInquery), validRequestStatusId);
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }
        public void UpdateRequestStatus(requests request)
        {
            request.REQ_STATUS =
            request.REQ_STATUS == (int)ValidtionStatusRequired.DocumentsRequiredCompleted ?
            (int)ValidtionStatusCompeleted.DocumentsCompleted :
            request.REQ_STATUS == (int)ValidtionStatusRequired.DataCorrectionRequired ?
            (int)ValidtionStatusCompeleted.DataCorrectionCompleted :
            request.REQ_STATUS == (int)ValidtionStatusRequired.RequiredCompletePaperworkNDCorrectData ?
            (int)ValidtionStatusCompeleted.PaperworkNDCorrectDataComplete : request.REQ_STATUS;
            request.LastRequestStatusDate = DateTime.Now;
            request.F_MIG = request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : request.F_MIG;

            Update(request);
        }
        public Tuple<int, string> CheckRequestRequirements(decimal? statusId, FarmInformation farmInformation, List<AttachmentFile> attachmentFiles)
        {

            if (statusId == (int)ValidtionStatusRequired.DocumentsRequiredCompleted)
            {
                if (attachmentFiles == null || !attachmentFiles.Any())
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, Infrastructure.Resources.Validations.Arabic.Ar_Responses.RequestRequireAttachments);
            }
            if (statusId == (int)ValidtionStatusRequired.DataCorrectionRequired)
            {
                if (farmInformation == null)
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, Infrastructure.Resources.Validations.Arabic.Ar_Responses.RequestRequiremenInfo);
            }
            if (statusId == (int)ValidtionStatusRequired.RequiredCompletePaperworkNDCorrectData)
            {
                if (!attachmentFiles.Any() || farmInformation == null)
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, Infrastructure.Resources.Validations.Arabic.Ar_Responses.RequireAttachmentsAndInfo);
            }

            return new Tuple<int, string>((int)RequestRequiremenstMessage.valid, string.Empty);
        }
        public bool IsRequestValidExpiryDate(requests request)
        {
            var expiryDate = request.RequestExpiryDate;
            return expiryDate > DateTime.Now;
        }
        public async Task UpdateExpiredRequest(requests request)
        {
            request.REQ_STATUS = (int)ExpiryDateStatus.CancelRequestStatus;
            request.LastRequestStatusDate = request.RequestExpiryDate;
            request.F_MIG = request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : request.F_MIG;
            request.IfNotified = true;
            await UpdateAsync(request);
        }
        public async Task PushExpiryOrCompeletedStatusRequest(requests request)
        {
            var pushList = new List<requests>() { request };
            var reponses = await _pushNotificationService.PushNotification(pushList);
            await UpdateNotifiedRequests(pushList, reponses);
        }
        public async Task UpdateRequesStatuMigrations(requests request, bool? ispaid)
        {
            request.REQ_STATUS = ispaid == true ? (decimal?)CategoryStatus.newRequest : (decimal?)CategoryStatus.UnderStudying;
            request.CORR_DELIVERY_DATE = request.REQ_STATUS == (decimal?)CategoryStatus.UnderStudying ? request.CORR_CREATE_DATE : null;
            request.LastRequestStatusDate = DateTime.Now;
            request.F_MIG = (decimal?)MigrationCodes.Migrated;
            await UpdateAsync(request);
        }
        public async Task<bool> IsRequestTypeValidForSlugs(string slug, string farmRequestType, bool isFarm)
        {
            if (string.IsNullOrEmpty(farmRequestType))
            {
                if (!isFarm)
                {
                    if (slug.Equals(Infrastructure.Resources.Validations.Arabic.Ar_Responses.MALR_11) || slug.Equals(Infrastructure.Resources.Validations.Arabic.Ar_Responses.MALR_22))
                    {
                        if (string.IsNullOrEmpty(farmRequestType))
                            return false;
                    }

                }
                if (isFarm)
                {
                    if (slug.Equals(Infrastructure.Resources.Validations.Arabic.Ar_Responses.MALR_17) || slug.Equals(Infrastructure.Resources.Validations.Arabic.Ar_Responses.MALR_06))
                    {
                        if (string.IsNullOrEmpty(farmRequestType))
                            return false;
                    }

                }
            }
            return true;
        }
        public async Task UpdateCancelRequest(requests request, string reason)
        {

            request.REQ_STATUS = (decimal?)RequestStatusCodes.CancelRequest;
            request.CancelReason = !string.IsNullOrEmpty(reason) ? reason : null;
            request.LastRequestStatusDate = DateTime.Now;
            request.CancelDate = DateTime.Now;
            request.F_MIG = request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : request.F_MIG;
            await UpdateAsync(request);

        }
        public async Task UpdateFeesRequestAsync(requests request, string expiryDate)
        {
            request.RequestExpiryDate = Convert.ToDateTime(expiryDate);
            request.F_MIG = request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : request.F_MIG;
            await UpdateAsync(request);
        }
        public async Task<IQueryable<requests>> NotifiedRequests()
        {
            return Where(s => s.IfNotified == true && s.F_DELETED == 0 && s.F_MIG == (int)MigrationCodes.Fetched);
        }
        public async Task<IQueryable<requests>> FindNotificationCancelRequest(string corrNumber)
        {
            return Where(s => s.IfNotified == true && s.F_DELETED == 0 && s.CORR_NUMBER.Equals(corrNumber));
        }
        public async Task UpdateNotifiedRequests(List<requests> requests, List<NotificationsResponseResult> notificationsResponse)
        {
            var notifiedRequests = requests.Where(s => notificationsResponse.Any(d => d.Request == s.CORR_NUMBER && d.Code == Ar_Responses.Ok && string.IsNullOrEmpty(d.PortlaMessageErrorCode)));
            foreach (var request in notifiedRequests)
            {
                request.IfNotified = false;
                await UpdateAsync(request);
            }
        }
        public async Task UpdateExpiryDateRequest(requests request)
        {
            request.REQ_STATUS = (int)ExpiryDateStatus.CancelRequestStatus;
            request.LastRequestStatusDate = request.RequestExpiryDate;
            request.F_MIG = request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : request.F_MIG;
            await UpdateAsync(request);

        }
        public async Task<requests> FindRequestByCorrId(decimal corrId)
        {
            return await FirstOrDefaultAsync(x => x.corr_id == corrId);
        }
        public async Task<requests> FindRequestWithIncludeUserInfo(string corrId)
        {
            return await Include(s => s.User).Where(s => s.CORR_NUMBER == corrId)?.FirstOrDefaultAsync();
        }

        public async Task<bool> CheckGreenHousenNumberValidForSlug(string slug, int? greenHouseNumber)
        {
            var greenHouseSlugs = new List<string>() {
               "MALR-08",
               "MALR-09",
               "MALR-19",
               "MALR-20" };

            if (greenHouseSlugs.Any(s => s.Equals(slug) && (greenHouseNumber is null || greenHouseNumber == 0)))
                return false;

            return true;
        }


        #endregion
    }
}
