using Core.Domain.Models.AppModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IUser
{
    public interface IUserFiles : IAppService<requests_documents>
    {
        Task AddFilesAsync(List<requests_documents> list);
    }
}
