using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.Payment.Confirmation;
using Core.Domain.Models.DTO.Payments.MainConfirmPayment;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IPayment.IConfirmations
{
    public interface IConfirmationsPaymentService : IAppService<RequestPayment>
    {
        bool CheckPaymentStatusIntegrity(decimal? requestStausId);
        Task<bool> CheckAuthorizingMechanisValue(string authorizingMechanismNumber);
     
        Task<RequestPayment> AddPaymentConfirmationAsync(RequestPayment paymentConfirmation, requests request, PaymentConfirmServiceDTO paymentConfirmServiceDTO);

        bool CheckServiceNoFees(string slug, decimal requestCategoryId);

        Task<bool> CheckIsConfirmedValid(string IsConfirmed );

        Task<bool> CheckIsRequestNewAndNotPiad(requests request, l_category category);
    }


}
