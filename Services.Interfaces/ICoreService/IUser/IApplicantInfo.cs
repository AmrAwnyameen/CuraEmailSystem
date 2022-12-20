using Core.Domain.Models.AppModels.CompanyInfo;
using Core.Domain.Models.AppModels.SiteInfo;

namespace Services.InterFaces.ICoreService.IUser
{
    public interface IApplicantInfo :  IAppService<Site>
    {

        Company SaveCompany(Company company);

        bool ChekUserValidity(Site user);

        Site FindByNationalId(Site user);

    }
}
