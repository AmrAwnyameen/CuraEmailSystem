using Core.Domain.Models.AppModels.SlugsInfo;
using Services.InterFaces.ICoreService.IServiceCodeSlug;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.ServiceCodeSlug
{
    public class CategorySlugService : AppService<Slug>, IServiceCodeSlug
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategorySlugService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckCategoryIsHemSelf(decimal categoryId, string slugCode)
        {
            var isRelatedWithCategory = await FirstOrDefaultAsync(s => s.l_category_id == categoryId && s.SlugName.Equals(slugCode));
            return isRelatedWithCategory != null && isRelatedWithCategory.IShimself ? true  : false;
          
        }

        public async Task<bool> CheckCategorySlugRelation(decimal categoryId, string slugCode)
        {
            var isSlugRelatedWithCategory = await AnyAsync(s => s.l_category_id == categoryId && s.SlugName.Equals(slugCode));
            return !isSlugRelatedWithCategory ?  false: true;
           
        }

        public async Task<Slug> FindSlugByName(string slug)
        {
            return await FirstOrDefaultAsync(s => s.SlugName.Equals(slug));
        }
    }
}
