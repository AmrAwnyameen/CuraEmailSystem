using Core.Domain.Models.AppModels;
using Services.InterFaces.ICoreService.ICitizenDocumntDeatils;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Citizen
{
    public class CitizenDocumntDeatilsService  : AppService<citizen_reply_required_documents>, ICitizenDocumntDeatilsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CitizenDocumntDeatilsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
    }
}
