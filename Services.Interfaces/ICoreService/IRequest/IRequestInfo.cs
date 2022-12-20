using Core.Domain.Models.AppModels.UserServices;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IRequest
{
    public interface IRequestInfo :  IAppService<ApplicantFarmRequest>
    {
        ApplicantFarmRequest GenerateApplicantFarmRequest(int headerId, decimal requestId, int userFarmId);

        Task<ApplicantFarmRequest> FindApplicantFarmRequestWithFarmInformation(decimal coorrId);
    }
}
