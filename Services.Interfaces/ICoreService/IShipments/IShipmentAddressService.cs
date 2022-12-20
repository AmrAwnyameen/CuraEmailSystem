using Core.Domain.Models.AppModels.Shipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IShipments
{
    public interface IShipmentAddressService : IAppService<ShipmentAddress>
    {
        Task<ShipmentAddress> FindShipmentAddressByRequestId(decimal requestId);
    }
}
