using Core.Domain.Models.AppModels;
using Services.InterFaces.ICoreService.IUser;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.User.Files
{
    public class UserFilesService : AppService<requests_documents>, IUserFiles
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserFilesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddFilesAsync(List<requests_documents> files)
        {
            await AddRangeAsync(files);
        }
    }
}
