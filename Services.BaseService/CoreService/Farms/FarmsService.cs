using Core.Domain.Models.AppModels.FarmInfo;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.IFarms;
using Services.InterFaces.ICoreService.IGovernorate;
using Services.InterFaces.ICoreService.ILookups;
using Services.InterFaces.ICoreService.IRequest;
using Services.InterFaces.ICoreService.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Farms
{
    public class FarmsService : AppService<FarmInformation>, IFarmsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFarm _userFarm;
        private readonly IRequestInfo _requestFarmUserInfo;
        private readonly IGovernorateService _governorateService;

        private readonly ILookupsService _lookupsService;
        public FarmsService(IUnitOfWork unitOfWork, ILookupsService lookupsService, IGovernorateService governorateService, IUserFarm userFarm, IRequestInfo requestInfo) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userFarm = userFarm;
            _requestFarmUserInfo = requestInfo;
            _governorateService = governorateService;
            _lookupsService = lookupsService;
        }

        public async Task<List<FarmInformation>> FindFarmsCustomProperties(List<FarmInformation> farms)
        {
            farms.ForEach(x => x.Governorate = (int.TryParse(x.Governorate.ToString(), out _) ?
                _governorateService.FirstOrDefault(w => w.code.Equals(x.Governorate.ToString())).description : ""));
            farms.ForEach(x => x.FarmActivityType = (_lookupsService.GetLookupsSpecificValue(x.FarmActivityType)));
            farms.ForEach(x => x.PropertyType = (_lookupsService.GetLookupsSpecificValue(x.PropertyType)));

            return farms;

        }

        public async Task<FarmInformation> FindFarmsBylId(int farmId, int farmType)
        {
            return farmType  == (int)FarmTypes.Farm ? await FirstOrDefaultAsync(s => s.Id == farmId && s.IsFarm) :
                 await FirstOrDefaultAsync(s => s.Id == farmId && !s.IsFarm);
        }

        public List<FarmInformation> FindFarmsByNationalId(string nationalID)
        {
            var validNationalId = Convert.ToDecimal(nationalID);
            var userFarms = _userFarm.Where(x => x.User.NATIONAL_NO == validNationalId).ToList();
            var farmRequets = _requestFarmUserInfo.Include(q => q.Requests).ToList().
                Where(s => userFarms.Any(x => x.Id == s.UserFarmId && s.Requests.REQ_STATUS == (int)UserFarmStatus.DocumentDeliveryToUser))
                .Select(s => s.UserFarmId).ToList();
            var farms= _userFarm.Where(x => farmRequets.Any(s=>s == x.Id)).Select(s=> s.FarmInformation).ToList();
            return farms;
        }
    }
}
