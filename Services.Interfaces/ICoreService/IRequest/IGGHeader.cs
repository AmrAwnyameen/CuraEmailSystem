using Core.Domain.Models.AppModels.Headers;
using Infrastructure.Helpers.ModalStates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IRequest
{
   public interface  IGGHeader :  IAppService<GGHeader>
    {
        Dictionary<string, string> GetGGHeader(HttpRequestMessage nameValueCollection);

        Task <GGHeader> GetValidGGHeaders(HttpRequestMessage nameValueCollection);

        bool CheckRequiredHeaders(HttpRequestMessage nameValueCollection);

        List<ModalStateResponse> CheckNullbelHeaders(HttpRequestMessage headers);

        ModalStateResponse GGNullbelRequiredValues(HttpRequestMessage headers);

         Task<GGHeader> AddGGHeaderAsync(GGHeader gGHeader, decimal corr_id);
    }
}
