using Core.Domain.Models.AppModels.Complains;
using Core.Domain.Models.AppModels.SiteInfo;
using Core.Domain.Models.DTO.Complaint;
using Services.InterFaces.ICoreService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService
{
    public class ComplaintService: AppService<Complaint>, IComplaintService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ComplaintService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Site MapUserCompliantModel(ComplaintDTO model)
        {
            var userMapping = new Site
            {
                ServiceCode = model.ServiceCode.ToString(),
                LKUP_GOVERNMENT_ID = int.TryParse(model.ApplicantGovernorate, out _) ? int.Parse(model.ApplicantGovernorate) : 0,
                MO_PHONE_NO = model.PhoneNumber.ToString(),
                NATIONAL_NO = decimal.TryParse(model.NationalID, out _) ? decimal.Parse(model.NationalID) : 0,
                Email = model.ApplicantEmail,
                ADDRESS = model.ApplicantAddress,
                NAME = model.ApplicantName
            };

            return userMapping;
        }
    }
}
