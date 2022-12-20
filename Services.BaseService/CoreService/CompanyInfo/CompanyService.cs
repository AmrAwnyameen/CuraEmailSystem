using Services.InterFaces.ICoreService.ICompany;
using Core.Domain.Models.AppModels.CompanyInfo;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.CompanyInfo
{
    public class CompanyService : AppService<Company>, ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
