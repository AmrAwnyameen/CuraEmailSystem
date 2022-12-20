using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.Payment.CategoryFeez;
using Core.Domain.Models.AppModels.Payment.FeesSettlement;
using Core.Domain.Models.DTO.Payments.Fees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IPayment.IFeesSettlemen
{
    public interface IFeesSettlemenService : IAppService<ServiceCategoryFeesSettlement>
    {
        List<ServiceCategoryFeesSettlement> FindCategoryFeesSettlements(int categoryFeesId);


        Task GetAmountForFeesSettlements(citizen_reply_details citizen_Reply_Details, ServiceCategoryFeesDTO serviceCategoryFeesDTO, ServiceCategoryFees serviceCategoryFees, List<CategoryFeesSettlementDTO> categoryFeesSettlementDTOs);
    }
}
