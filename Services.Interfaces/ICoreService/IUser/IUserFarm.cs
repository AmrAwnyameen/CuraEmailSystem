using Core.Domain.Models.AppModels.FarmInfo;
using Core.Domain.Models.AppModels.SiteInfo;
using Core.Domain.Models.AppModels.UserServices;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IUser
{
    public interface IUserFarm : IAppService<UserFarms>
    {
        UserFarms AddUserFarms(Site applicationUser, FarmInformation farmInformation);
        Task<UserFarms> FindUserFarmWithFarmInfo(int userFarmId);

        Task<UserFarms> FindUserFarmByFarmId(int? farmId);
    }
}
