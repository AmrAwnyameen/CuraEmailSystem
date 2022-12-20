using Core.Domain.Models.AppModels.FarmInfo;
using Core.Domain.Models.AppModels.LookupInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.ILookups
{
    public interface ILookupsService : IAppService<Lookup>
    {
        Task<Lookup> GetByLookupIdAsync(int code);

        Task<bool> CheckLookupCode(int? code);
        Task<List<LookupData>> GetByAttcahmentLookupId(int code, int? parentId);
        Task<List<LookupData>> GetByServiceLookupId(int code);
        Task<IList<LookupData>> GovernoratesLookups();
        Task<ICollection<LookupData>> AddSlugAttachments(List<LookupData> lookupDatas);
        Task<Tuple<int, string>> CheckIntegrityForFarmsInformations(string propertyType, string requestType, string activityType);
        string GetLookupsSpecificValue(string item);

        Task<bool> CheckFarmPropertyValidations(string slug);
    }
}
