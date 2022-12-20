using Services.Interfaces.IBaseServices;
using Services.InterFaces.ICoreService;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService
{
    public class AppService<TEntity> : BaseService<TEntity>,IBaseService<TEntity> ,IAppService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


    }
}
