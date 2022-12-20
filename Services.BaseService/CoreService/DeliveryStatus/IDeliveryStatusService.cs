using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.RequestDeliveryStatus;
using Core.Domain.Models.AppModels.Shipments;
using Infrastructure.Helpers.Enums;
using Services.BaseService.CoreService;
using Services.InterFaces.ICoreService.IDeliveryStatus;
using Services.InterFaces.ICoreService.IRequest;
using System;
using System.Globalization;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.InterFaces.CoreService.DeliveryStatuses
{
    public class DeliveryStatusService : AppService<DeliveryStatus>, IDeliveryStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestService _requestService;

        #region services
      
        public DeliveryStatusService(IUnitOfWork unitOfWork, IRequestService requestService) : base(unitOfWork)
        {
            _requestService = requestService;
            _unitOfWork = unitOfWork;
        }

        public async Task<requests> UpdatePostalStatus(requests request, decimal postalCode)
        {
            request.REQ_STATUS =
            //53
            postalCode ==
            (int)ShipmentInfoCodes.Shipmentdelivered ?
            (int)RequestStatusCodes.documentHandedoverToCitizen :

            //112
            postalCode ==
            (int)ShipmentInfoCodes.thePersonHowSentToHimDeliveryNotFound ?
            (int)ShipmentInfoCodes.thePersonHowSentToHimDeliveryNotFound :

            //27
            postalCode ==(int)PaymentDeliveryCodes.CompeletedPostalPayment ?
            (int)PaymentDeliveryCodes.CompeletedPostalPayment : request.REQ_STATUS;
           
            request.F_MIG = request.F_MIG ==
                (int)MigrationCodes.Fetched ? 
                (int)MigrationCodes.MigratedUpdate :
                request.F_MIG;

            request.LastRequestStatusDate = DateTime.Now;
            if (request.REQ_STATUS == (int)RequestStatusCodes.documentHandedoverToCitizen)
                request.IfNotified = true;
            return request;
        }

        public async Task ChangeShipmentStatus(DeliveryStatus deliveryStatus, ShimentInfoStatus shimentInfoStatus, requests request, string timeStamp)
        {
            deliveryStatus.RequestId = request.corr_id;
            deliveryStatus.ShimentStatusId = shimentInfoStatus.Id;
            deliveryStatus.TimeStamp = DateTime.ParseExact(timeStamp, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            await AddAsync(deliveryStatus);
        }

        public async Task<bool> CheckCompeletePostalPaymentStatus(decimal status)
        {
            return true ? status == (int)PaymentDeliveryCodes.CompeletedPostalPayment :false;
            
        }

        #endregion
    }
}
