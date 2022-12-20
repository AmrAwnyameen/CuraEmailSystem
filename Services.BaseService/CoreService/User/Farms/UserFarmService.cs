using Core.Domain.Models.AppModels.FarmInfo;
using Core.Domain.Models.AppModels.SiteInfo;
using Core.Domain.Models.AppModels.UserServices;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.IUser;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.User.Farms
{
    public class UserFarmService : AppService<UserFarms> , IUserFarm 
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserFarmService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  UserFarms AddUserFarms(Site user , FarmInformation farmInformation)
        {
            var userFarm = new UserFarms()
            {
                FarmId = farmInformation.Id,
                UserId = user.Id,
                F_MIG = (int)MigrationCodes.Migrated
        };

            return userFarm;
        }

        public async Task<UserFarms> FindUserFarmByFarmId(int? farmId)
        {
            return await Include(s => s.FarmInformation).Where(s => s.FarmId == farmId)?.FirstOrDefaultAsync();
        }

        public async Task<UserFarms> FindUserFarmWithFarmInfo(int userFarmId)
        {
            return await Include(s => s.FarmInformation).Where(s => s.Id == userFarmId)?.FirstOrDefaultAsync();
        }
    }
}
