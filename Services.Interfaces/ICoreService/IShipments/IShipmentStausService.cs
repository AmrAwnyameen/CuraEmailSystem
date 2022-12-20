using Core.Domain.Models.AppModels.Shipments;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IShipments
{
    public interface IShipmentStausService  : IAppService<ShimentInfoStatus>
    {
        Task<ShimentInfoStatus> FindShipmentStatusCode(decimal code);
    }
}
