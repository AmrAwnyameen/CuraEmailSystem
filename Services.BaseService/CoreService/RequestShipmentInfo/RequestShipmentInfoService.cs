using System.Threading.Tasks;
using Core.Domain.Models.AppModels.CMS;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.IRequestShipmentInfo;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.RequestShipmentInfo
{
    public class RequestShipmentInfoService : AppService<Request_ShipmentInfo>, IRequestShipmentInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestShipmentInfoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Request_ShipmentInfo> AddRequestShipmentInfo(decimal requestId)
        {
           var requestShipmentInfo = new Request_ShipmentInfo()
           {
               ShipmentNumber = string.Empty,
               DocumentDescription = string.Empty, 
               RequireDocumentFromCitizen = (int)RequestShipMentStatus.None,
               RequestId = requestId,
               ReturnAddressID = (int)RequestShipMentStatus.ReaturnAdress,
               VendorAddressID = (int)RequestShipMentStatus.VendorAdress,
               F_MIG =(int)MigrationCodes.Migrated
           };

          await AddAsync(requestShipmentInfo);
          return requestShipmentInfo;
        }
    }
}
