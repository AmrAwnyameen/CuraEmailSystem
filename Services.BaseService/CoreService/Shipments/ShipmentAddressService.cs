using Core.Domain.Models.AppModels.Shipments;
using Services.BaseService.CoreService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.InterFaces.ICoreService.IShipments
{
    public class ShipmentAddressService : AppService<ShipmentAddress>, IShipmentAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShipmentAddressService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShipmentAddress> FindShipmentAddressByRequestId(decimal requestId)
        {
            return await FirstOrDefaultAsync(s => s.RequestId == requestId);
        }
    }
}
