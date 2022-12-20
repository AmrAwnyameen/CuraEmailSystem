using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.RequestDeliveryStatus;
using Core.Domain.Models.AppModels.Shipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IDeliveryStatus
{
    public interface IDeliveryStatusService : IAppService<DeliveryStatus>
    {
        Task<requests> UpdatePostalStatus(requests request, decimal postalCode);

        Task<bool> CheckCompeletePostalPaymentStatus(decimal status);
        Task ChangeShipmentStatus(DeliveryStatus deliveryStatus, ShimentInfoStatus shimentInfoStatus, requests request, string timeStamp);
    }
}
