using Core.Domain.Context;
using Core.Domain.Models.ViewModels.User;
using Infrastructure.Resources.Validations.English;
using Services.InterFaces.ICoreService.IUser;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;


namespace Services.BaseService.CoreService.User.Information
{
    public class UserService : AppService<ApplicationUser>, IUserService
    {
        #region Container
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Services
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await FirstOrDefaultAsync(s => s.Email.Equals(email));
        }
        public async Task RegisterRecoveryEmail(ApplicationUser user, string email)
        {
            user.RecoveryEmail = email;
            user.verified = true;
            await UpdateAsync(user);
        }
        public async Task<List<UserViewModel>> SearchByEmail(string email)
        {
            var users = await Where(s => s.UserName.Contains(email)).Select(s => new UserViewModel() { Email = s.Email }).ToListAsync();

            return users.Any() ? users : new List<UserViewModel>() { new UserViewModel() { Email = ValidationResponses.EmailNotFound } };
        }
        #endregion
    }
}
