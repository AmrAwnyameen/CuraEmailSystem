using Core.Domain.Models.AppModels.Payment.CategoryFeez;
using Core.Domain.Models.AppModels.Payment.FeesSettlement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IPayment.IServiceFees
{
    public interface IServiceCategoryFees : IAppService<ServiceCategoryFees>
    {
        Task<ServiceCategoryFees> FindServiceCategoryFees(decimal? serviceCodeId);
    }
}
