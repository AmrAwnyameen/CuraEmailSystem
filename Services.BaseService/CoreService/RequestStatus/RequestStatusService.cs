using Core.Domain.Models.AppModels;
using Services.InterFaces.ICoreService.IRequestStatus;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.RequestStatus
{
    public class RequestStatusService : AppService<sysl_request_status>, IRequestStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestStatusService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
