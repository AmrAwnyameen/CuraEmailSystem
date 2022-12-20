using Core.Domain.Models.AppModels.FarmInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IFarms
{
    public interface IFarmsServices : IAppService<FarmInformation>
    {
        List<FarmInformation> FindFarmsByNationalId(string nationalID);

       Task<FarmInformation> FindFarmsBylId(int farmId, int farmType);

        Task<List<FarmInformation>> FindFarmsCustomProperties(List<FarmInformation> farmInformation);
    }
}
