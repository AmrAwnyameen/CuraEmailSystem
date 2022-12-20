using Core.Domain.Models.AppModels.Shipments;
using Services.InterFaces.ICoreService.IShipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Shipments
{
    public class ShipmentStausService : AppService<ShimentInfoStatus>, IShipmentStausService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShipmentStausService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShimentInfoStatus> FindShipmentStatusCode(decimal code)
        {
            return await FirstOrDefaultAsync(s => s.Code == code);
        }
    }
}
