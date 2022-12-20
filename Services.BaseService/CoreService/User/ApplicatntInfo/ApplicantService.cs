using Core.Domain.Models.AppModels.CompanyInfo;
using Core.Domain.Models.AppModels.SiteInfo;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.IUser;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.User.ApplicatntInfo
{
    public class ApplicantService : AppService<Site>, IApplicantInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicantService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ChekUserValidity(Site user)
        {
            var userInfo = FirstOrDefault(s => s.NATIONAL_NO.Equals(user.NATIONAL_NO));
            return userInfo != null ? true : false;
        }

        public Site FindByNationalId(Site user)
        {
            return FirstOrDefault(s => s.NATIONAL_NO.Equals(user.NATIONAL_NO) && s.ChannelId == (int)ChannelCodes.DigitalEgypt);
        }

        public Company SaveCompany(Company company)
        {
            if (company != null)
            {
                _unitOfWork.Repository<Company>().Add(company);
                _unitOfWork.Save();
                return company;
            };

            return null;
        }
      

    }
}

