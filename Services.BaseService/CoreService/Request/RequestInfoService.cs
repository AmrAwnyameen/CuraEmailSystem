using Core.Domain.Models.AppModels.UserServices;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.IRequest;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Request
{
    public class RequestInfoService : AppService<ApplicantFarmRequest>, IRequestInfo
    {

        #region ctor
        private readonly IUnitOfWork _unitOfWork;
        public RequestInfoService(IUnitOfWork unitOfWork, IGGHeader ggherder) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region services
        public async Task<ApplicantFarmRequest> FindApplicantFarmRequestWithFarmInformation(decimal coorrId)
        {
            return await _unitOfWork.Repository<ApplicantFarmRequest>().Include(s => s.UserFarms.FarmInformation).Where(s => s.RequestId == coorrId)?.FirstOrDefaultAsync();
        }

        public ApplicantFarmRequest GenerateApplicantFarmRequest(int headerId, decimal requestId, int userFarmId)
        {
            var reuestInfo = new ApplicantFarmRequest()
            {
                CreationDate = DateTime.Now,
                HeaderId = headerId,
                RequestId = requestId,
                UserFarmId = userFarmId,
                F_MIG=(int)MigrationCodes.Migrated
            };
            return reuestInfo;
        }

        #endregion
    }
}
