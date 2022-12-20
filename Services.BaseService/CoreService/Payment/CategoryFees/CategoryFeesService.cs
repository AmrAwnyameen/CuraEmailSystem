using Core.Domain.Models.AppModels.Payment.CategoryFeez;
using Core.Domain.Models.AppModels.Payment.FeesSettlement;
using Services.InterFaces.ICoreService.IPayment.IServiceFees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Payment.CategoryFees
{
    public class CategoryFeesService : AppService<ServiceCategoryFees>, IServiceCategoryFees
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryFeesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceCategoryFees> FindServiceCategoryFees(decimal? serviceCodeId)
        {
            return await FirstOrDefaultAsync(s => s.CategoryId == serviceCodeId);
        }
    }
}
