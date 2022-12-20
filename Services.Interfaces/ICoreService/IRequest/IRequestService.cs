using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.AttachementInfo;
using Core.Domain.Models.AppModels.FarmInfo;
using Core.Domain.Models.AppModels.SiteInfo;
using Core.Domain.Models.DTO.Farm;
using Core.Domain.Models.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IRequest
{
    public interface IRequestService : IAppService<requests>
    {
        Task<requests> AddnewRequest(Site applicationUser, int? deliveryMethod, int? requesterType);

        Task<requests> FindRequestByCorrId(decimal corrId);

        Task<requests> FindRequestWithIncludeUserInfo(string coorrNumber);
        Task<requests> AddApplicationUserRequest(Site applicationUser);
        string GenerateCorrNumber(requests request);
        Task<requests> GetRequestByCorrNumber(decimal requestId);
        bool CheckStatusForDamageIntgrity(decimal? requestStatusId);
        bool CheckUpdateStatusOrchaIntgrity(decimal? requestStatusId);
        void UpdateRequestStatus(requests requests);
        bool IsRequestValidExpiryDate(requests request);
        Tuple<int, string> CheckRequestRequirements(decimal? statusId, FarmInformation farmInformation , List<AttachmentFile> attachmentFiles);

        Task UpdateExpiredRequest(requests requests);

        Task UpdateRequesStatuMigrations(requests requests, bool? ispaid);

        Task UpdateCancelRequest(requests requests, string reason);

        Task UpdateFeesRequestAsync(requests requests, string expiryDate);

        Task<bool> IsRequestTypeValidForSlugs(string slug , string farmRequestType, bool isFarm);

        Task<IQueryable<requests>> NotifiedRequests();

        Task<IQueryable<requests>> FindNotificationCancelRequest(string coorNumber);

        Task UpdateNotifiedRequests(List<requests> requests,List<NotificationsResponseResult> notificationsResponseResults);

        Task UpdateExpiryDateRequest(requests request);

        Task PushExpiryOrCompeletedStatusRequest(requests request);

        bool CheckInqueryValidtionStatus(decimal? requestStatusId);

        Task<requests> UpdatePaymentRequestStatus(requests requests);

        Task<bool> CheckGreenHousenNumberValidForSlug(string slug, int? greenHouseNumber);


    }
}
