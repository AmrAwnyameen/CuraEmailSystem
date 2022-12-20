using Core.Domain.Models.AppModels;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IUser
{
    public interface IUserRequestServiceCodes : IAppService<l_category>
    {
        Task<l_category> FindServiceCode(decimal serviceCodeId);
    }
}
