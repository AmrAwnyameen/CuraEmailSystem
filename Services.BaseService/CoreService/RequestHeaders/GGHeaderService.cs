using Core.Domain.Models.AppModels.Headers;
using Infrastructure.Helpers.Enums;
using Infrastructure.Helpers.ModalStates.Models;
using Services.InterFaces.ICoreService.IRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.RequestHeaders
{
    public class GGHeaderService : AppService<GGHeader>, IGGHeader
    {
        #region ctor
        private readonly IUnitOfWork _unitOfWork;
        private readonly List<ModalStateResponse> _NullabelRequiredKeys;
        public GGHeaderService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _NullabelRequiredKeys = new List<ModalStateResponse>();
        }
        #endregion

        #region services
        public bool CheckRequiredHeaders(HttpRequestMessage headers)
        {
            var keysPerValues = GetGGHeader(headers);
            if (keysPerValues.Any(x => x.Key.ToLower() == "correlationId".ToLower() && !string.IsNullOrEmpty(x.Value)) &&
                keysPerValues.Any(x => x.Key.ToLower() == "originatingChannel".ToLower() && !string.IsNullOrEmpty(x.Value)) &&
                keysPerValues.Any(x => x.Key.ToLower() == "ServiceSlug".ToLower() && !string.IsNullOrEmpty(x.Value)))
                return true;

            return false;
        }
        public async Task<GGHeader> GetValidGGHeaders(HttpRequestMessage headers)
        {
            try
            {
                var requestHeader = new GGHeader();
                if (!CheckRequiredHeaders(headers) || CheckNullbelHeaders(headers).Any())
                    return null;

                var keysPerValues = GetGGHeader(headers);
                requestHeader.CorrelationId = keysPerValues.Any(x => x.Key.ToLower() == "correlationId".ToLower() && !string.IsNullOrEmpty(x.Value)) ? keysPerValues.Where(x => x.Key.ToLower() == "correlationId".ToLower()).First().Value : "";
                requestHeader.OriginatingChannel = keysPerValues.Any(x => x.Key.ToLower() == "originatingChannel".ToLower() && !string.IsNullOrEmpty(x.Value)) ? int.Parse(keysPerValues.Where(x => x.Key.ToLower() == "originatingChannel".ToLower()).First().Value.ToString()) : 0;
                requestHeader.channelRequestId = keysPerValues.Any(x => x.Key.ToLower() == "channelRequestId".ToLower() && !string.IsNullOrEmpty(x.Value)) ? keysPerValues.Where(x => x.Key.ToLower() == "channelRequestId".ToLower()).First().Value : "";
                requestHeader.OriginatingUserType = keysPerValues.Any(x => x.Key.ToLower() == "originatingUserType".ToLower() && !string.IsNullOrEmpty(x.Value)) ? int.Parse(keysPerValues.Where(x => x.Key.ToLower() == "originatingUserType".ToLower()).First().Value.ToString()) : 0;
                requestHeader.ServiceEntityId = keysPerValues.Any(x => x.Key.ToLower() == "serviceEntityId".ToLower() && !string.IsNullOrEmpty(x.Value)) ? int.Parse(keysPerValues.Where(x => x.Key.ToLower() == "serviceEntityId".ToLower()).First().Value.ToString()) : 0;
                requestHeader.OriginatingUserIdentifier = keysPerValues.Any(x => x.Key.ToLower() == "originatingUserIdentifier".ToLower() && !string.IsNullOrEmpty(x.Value)) ? keysPerValues.Where(x => x.Key.ToLower() == "originatingUserIdentifier".ToLower()).First().Value : "";
                requestHeader.ServiceSlug = keysPerValues.Any(x => x.Key.ToLower() == "ServiceSlug".ToLower() && !string.IsNullOrEmpty(x.Value)) ? keysPerValues.Where(x => x.Key.ToLower() == "ServiceSlug".ToLower()).First().Value : "";
                requestHeader.CreationDate = DateTime.Now;
                requestHeader.F_MIG = (int)MigrationCodes.Migrated;
                return requestHeader;

            }
            catch (Exception)
            {

                return null;
            }
        }
        public Dictionary<string, string> GetGGHeader(HttpRequestMessage nameValueCollection)
        {
            var headers = new Dictionary<string, string>();
            foreach (var header in nameValueCollection.Headers)
            {
                headers.Add(header.Key, header.Value.FirstOrDefault().ToString());
            }
            return headers;
        }
        public List<ModalStateResponse> CheckNullbelHeaders(HttpRequestMessage headers)
        {
            var headersValues = GetGGHeader(headers);
            if (!headersValues.Any(x => x.Key.ToLower() == "correlationId".ToLower() && !string.IsNullOrEmpty(x.Value)))
            {
                _NullabelRequiredKeys.Add(new ModalStateResponse() { ResponseCode = int.Parse(Infrastructure.Resources.Validations.Arabic.Ar_Responses.correlationIdRequired), ResponseMessage = "correlationId is required" });
            }
            if (headersValues.Any(x => x.Key.ToLower() == "correlationId".ToLower() && !string.IsNullOrEmpty(x.Value)))
            {
                var correlationId = headersValues.FirstOrDefault(x => x.Key.ToLower() == "correlationId".ToLower() && !string.IsNullOrEmpty(x.Value)).Value;
                if (correlationId.Equals("\"\"") || correlationId.Equals("") || correlationId.Equals("\" \""))
                {
                    _NullabelRequiredKeys.Add(new ModalStateResponse() { ResponseCode = int.Parse(Infrastructure.Resources.Validations.Arabic.Ar_Responses.correlationIdRequired), ResponseMessage = "correlationId is required" });
                }
            }
            if (headersValues.Any(x => x.Key.ToLower() == "correlationId".ToLower() && string.IsNullOrEmpty(x.Value)))
            {
                _NullabelRequiredKeys.Add(new ModalStateResponse() { ResponseCode = int.Parse(Infrastructure.Resources.Validations.Arabic.Ar_Responses.correlationIdRequired), ResponseMessage = "correlationId is required" });
            }
            if (!headersValues.Any(x => x.Key.ToLower() == "ServiceSlug".ToLower() && !string.IsNullOrEmpty(x.Value)))
            {
                _NullabelRequiredKeys.Add(new ModalStateResponse() { ResponseCode = int.Parse(Infrastructure.Resources.Validations.Arabic.Ar_Responses.ServiceSlugRequired), ResponseMessage = "ServiceSlug is required" });
            }
            if (!headersValues.Any(x => x.Key.ToLower() == "originatingChannel".ToLower() && !string.IsNullOrEmpty(x.Value)))
            {
                _NullabelRequiredKeys.Add(new ModalStateResponse() { ResponseCode = int.Parse(Infrastructure.Resources.Validations.Arabic.Ar_Responses.originatingRequired), ResponseMessage = "originatingChannel is required" });
            }
            if (headersValues.Any(x => x.Key.ToLower() == "serviceEntityId".ToLower()) && !int.TryParse(headersValues.Where(z => z.Key.ToLower() == "serviceEntityId".ToLower()).FirstOrDefault().Value.ToString(), out _))
            {
                _NullabelRequiredKeys.Add(new ModalStateResponse() { ResponseMessage = Infrastructure.Resources.Validations.Arabic.Ar_Responses.serviceEntityIdNotValid, ResponseCode = (int)HeaderResponseCodes.serviceEntityId });
            }
            if (headersValues.Any(x => x.Key.ToLower() == "originatingChannel".ToLower() && !string.IsNullOrEmpty(x.Value)) && !int.TryParse(headersValues.Where(z => z.Key.ToLower() == "originatingChannel".ToLower()).First().Value.ToString(), out _))
            {
                _NullabelRequiredKeys.Add(new ModalStateResponse() { ResponseMessage = Infrastructure.Resources.Validations.Arabic.Ar_Responses.originatingChannelNotValid, ResponseCode = (int)HeaderResponseCodes.originatingChannel });

            }
            if (headersValues.Any(x => x.Key.ToLower() == "originatingUserType".ToLower()) && !int.TryParse(headersValues.Where(z => z.Key.ToLower() == "originatingUserType".ToLower()).First().Value.ToString(), out _))
            {
                _NullabelRequiredKeys.Add(new ModalStateResponse() { ResponseMessage = Infrastructure.Resources.Validations.Arabic.Ar_Responses.originatingUserTypeNotValid, ResponseCode = (int)HeaderResponseCodes.originatingUserType });
            }

            return _NullabelRequiredKeys;
        }
        public ModalStateResponse GGNullbelRequiredValues(HttpRequestMessage headers)
        {
            return _NullabelRequiredKeys.Any() ? _NullabelRequiredKeys.Distinct().ToList()?.FirstOrDefault() : CheckNullbelHeaders(headers)?.FirstOrDefault();
        }

        public async Task<GGHeader> AddGGHeaderAsync(GGHeader gGHeader, decimal corr_id)
        {
            gGHeader.F_MIG = (int)MigrationCodes.Migrated;
            gGHeader.RequestId = Convert.ToDecimal(corr_id);
            await AddAsync(gGHeader);
            return gGHeader;
        }
        #endregion

    }
}
