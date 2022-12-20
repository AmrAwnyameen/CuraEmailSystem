using Core.Domain.Models.AppModels;
using Services.InterFaces.ICoreService.IGovernorate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Governorate
{
    public class GovernorateService : AppService<l_government>, IGovernorateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GovernorateService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<l_government> FindGovernorateById(int governorateId)
        {
            return await FirstOrDefaultAsync(s => s.Id == governorateId);
        }
    }
}
