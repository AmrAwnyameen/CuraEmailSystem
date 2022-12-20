using Core.Domain.Models.AppModels.CMS;
using Services.InterFaces.ICoreService.IRequest;
using System.Data.Entity;
using System.Linq;
using Infrastructure.Helpers.Enums;
using UnitOfWork.Data.IUnitOfWork;
using Core.Domain.Models.AppModels;

namespace Services.BaseService.CoreService.Request
{
    public class RequestShipmentAddressService : AppService<Request_ShipmentInfo>, IRequestShipmentAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestShipmentAddressService(IUnitOfWork unitOfWork, IGGHeader ggherder) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Request_ShipmentInfo GetByRequestIdAndShipmentNumber(decimal requestId, string shipmentNumber)
        {
            return _unitOfWork.Repository<Request_ShipmentInfo>().Include(s=> s.Request).Where(x => x.RequestId == requestId && x.Request.DeliveryMethod == (int)ShipmentDelivery.Postal)
                .Include(x => x.ReturnAddress)
                .Include(x => x.VendorAddress)
                .FirstOrDefault();
        }

        public Request_ShipmentInfo UpdateShipmentRequestStatus(Request_ShipmentInfo requestShipment, string shipmentNumber, requests request)
        {
            requestShipment.ShipmentNumber = shipmentNumber;
            requestShipment.F_MIG = request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : requestShipment.F_MIG;
            return requestShipment;
        }
    }
}
