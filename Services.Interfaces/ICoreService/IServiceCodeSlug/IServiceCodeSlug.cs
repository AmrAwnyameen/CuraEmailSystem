using Core.Domain.Models.AppModels.SlugsInfo;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IServiceCodeSlug
{
    public interface IServiceCodeSlug : IAppService<Slug>
    {
        Task<bool> CheckCategorySlugRelation(decimal categoryId, string slugCode);

        Task<bool> CheckCategoryIsHemSelf(decimal categoryId, string slugCode);

        Task<Slug> FindSlugByName(string slug);
    }
}
