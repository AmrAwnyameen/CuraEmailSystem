using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.Payment.CategoryFeez;
using Core.Domain.Models.AppModels.Payment.FeesSettlement;
using Core.Domain.Models.DTO.Payments.Fees;
using Services.InterFaces.ICoreService.IPayment.IFeesSettlemen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Payment.CategoryFeesSettlement
{
    public class FeesSettlementService : AppService<ServiceCategoryFeesSettlement>, IFeesSettlemenService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeesSettlementService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task GetAmountForFeesSettlements(citizen_reply_details citizenReply,
            ServiceCategoryFeesDTO categoryFeesMapping, ServiceCategoryFees categoryFees,
            List<CategoryFeesSettlementDTO> categoryFeesSettlementDTOs)
        {
            if (categoryFeesSettlementDTOs.Count() > 1)
            {
                foreach (var item in categoryFeesMapping.SettlementAmounts)
                {
                    foreach (var categoryFeesSettlement in categoryFeesSettlementDTOs.Where(s=> s.Id == item.Id))
                    {
                        categoryFees.RequestFees = (decimal)citizenReply.PaymentAmount;
                        item.Amount = (decimal)GetAmountValueWithPercentage((decimal)citizenReply.PaymentAmount, categoryFeesSettlement.Amount);
                    }
                }
            }
            else
            {
                categoryFees.RequestFees = (decimal)citizenReply.PaymentAmount;
                categoryFeesMapping.SettlementAmounts.ForEach(s => s.Amount = (decimal)citizenReply.PaymentAmount);
            }
        }

        public List<ServiceCategoryFeesSettlement> FindCategoryFeesSettlements(int categoryFeesId)
        {
            return Where(s => s.CategoryFeezId == categoryFeesId).ToList();
        }

        private double GetAmountValueWithPercentage(decimal amount, decimal percentage)
        {
            var paymentAmount = Convert.ToInt32(amount);
            var paymentPercentage = Convert.ToInt32(percentage);
            return paymentAmount * (paymentPercentage / (double)100);
        }
    }
}
