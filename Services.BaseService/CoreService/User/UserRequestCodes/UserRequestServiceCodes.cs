using Core.Domain.Models.AppModels;
using Services.InterFaces.ICoreService.IUser;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.User.UserRequestCodes
{
    public class UserRequestServiceCodes : AppService<l_category>, IUserRequestServiceCodes
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRequestServiceCodes(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<l_category> FindServiceCode(decimal serviceCodeId)
        {
            return await FirstOrDefaultAsync(s => s.id == serviceCodeId);
        }
    }
}
