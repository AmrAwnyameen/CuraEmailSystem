using System.Threading.Tasks;
using Core.Domain.Models.AppModels.CMS;

namespace Services.InterFaces.ICoreService.IRequestShipmentInfo
{
    public interface IRequestShipmentInfoService: IAppService<Request_ShipmentInfo>
    {
        Task<Request_ShipmentInfo> AddRequestShipmentInfo(decimal requestId);
    }
}