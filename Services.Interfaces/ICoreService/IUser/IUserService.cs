using Core.Domain.Context;
using Core.Domain.Models.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IUser
{
    public interface IUserService : IAppService<ApplicationUser> 
    {
        #region Services
        Task RegisterRecoveryEmail(ApplicationUser user, string email);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<List<UserViewModel>> SearchByEmail(string email);
        #endregion

    }
}
