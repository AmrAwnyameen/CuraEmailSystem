using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.Payment.Confirmation;
using Core.Domain.Models.DTO.Payments.MainConfirmPayment;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.IPayment.IConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Payment.Confirmation
{
    public class ConfirmationsPaymentService : AppService<RequestPayment>, IConfirmationsPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region services
       
        public ConfirmationsPaymentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckAuthorizingMechanisValue(string authorizingMechanismNumber)
        {
            var authorizingNumbers = new List<string>() {
                ConfirmAuthorizingMechanism.Card.ToString(),
                ConfirmAuthorizingMechanism.Channel.ToString(),
                ConfirmAuthorizingMechanism.Meeza.ToString() };
            return authorizingNumbers.Any(s => s.Equals(authorizingMechanismNumber)) ? true : false;
        }

        public async Task<bool> CheckIsConfirmedValid(string IsConfirmed)
        {
            if (!IsConfirmed.Equals(ConfirmIsConfirmed.Yes.ToString()) && !IsConfirmed.Equals(ConfirmIsConfirmed.No.ToString()))
                return false;

            return true;
        }

        public bool CheckPaymentStatusIntegrity(decimal? requestStausId)
        {
            var requestId = Convert.ToInt32(requestStausId);
            return Enum.IsDefined(typeof(ValidtionPaymentStatus), requestId);
        }

        public bool CheckServiceNoFees(string slug, decimal requestCategoryId)
        {
            var slugNofeez = new List<string>() {
               "MALR-05",
               "MALR-06",
               "MALR-16",
               "MALR-17" };

            var categoryId = Convert.ToInt32(requestCategoryId);
            if (Enum.IsDefined(typeof(CategoryNoFees), categoryId) || slugNofeez.Any(s => s.Equals(slug)))
                return true;

            return false;
        }

        public async Task<RequestPayment> AddPaymentConfirmationAsync(RequestPayment paymentConfirmation, requests request, PaymentConfirmServiceDTO model)
        {
            paymentConfirmation.RequestId = request.corr_id;
            paymentConfirmation.F_MIG = (int?)(request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : request.F_MIG);
            paymentConfirmation.PaymentRequestTotalAmount = (decimal)model.PaymentRequestInitiationRes.PaymentRequestTotalAmount;
            paymentConfirmation.CollectionFeesAmount = (decimal)model.PaymentRequestInitiationRes.CollectionFeesAmount;
            await AddAsync(paymentConfirmation);
            return paymentConfirmation;
        }

        public async Task<requests>UpdatePaymentStatus(requests request)
        {
            //update  STATUS
            request.REQ_STATUS =
            request.REQ_STATUS ==
            (int)ValidtionPaymentStatus.newRequest ?
            (int)CategoryStatus.UnderStudying :
            request.REQ_STATUS == (int)ValidtionStatusPayment.PaymentRequired ?
            (int)ValidtionStatusPayment.PaymentCompeleted : request.REQ_STATUS;

            //update request 
            request.LastRequestStatusDate = DateTime.Now;
            request.CORR_DELIVERY_DATE = DateTime.Now;
            request.F_MIG = request.F_MIG == (int)MigrationCodes.Fetched ? (int)MigrationCodes.MigratedUpdate : request.F_MIG;

            await _unitOfWork.Repository<requests>().UpdateAsync(request);
            return request;
        }

        public async Task<bool> CheckIsRequestNewAndNotPiad(requests request, l_category category)
        {
            if ((request.REQ_STATUS == (int)ValidtionPaymentStatus.newRequest) && (category.IsPaid == false || category.IsPaid == null))
                return true;

            return false;
        }

        #endregion
    }
}
