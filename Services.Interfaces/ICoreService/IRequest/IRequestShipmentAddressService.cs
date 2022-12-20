using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IRequest
{
    public interface IRequestShipmentAddressService : IAppService<Request_ShipmentInfo>
    {
        Request_ShipmentInfo GetByRequestIdAndShipmentNumber(decimal requestId, string shipmentNumber);

        Request_ShipmentInfo UpdateShipmentRequestStatus(Request_ShipmentInfo request_ShipmentInfo, string shipmentNumber, requests request);
    }
}
