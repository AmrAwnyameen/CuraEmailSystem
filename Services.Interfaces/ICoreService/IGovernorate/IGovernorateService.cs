using Core.Domain.Models.AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IGovernorate
{
    public interface IGovernorateService :  IAppService<l_government>
    {
        Task<l_government> FindGovernorateById(int governorateId);
    }
}
