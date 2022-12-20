using Core.Domain.Models.AppModels.Complains;
using Core.Domain.Models.AppModels.SiteInfo;
using Core.Domain.Models.DTO.Complaint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService
{
    public interface IComplaintService : IAppService<Complaint>
    {
        Site MapUserCompliantModel(ComplaintDTO complaintDTO);
    }
}
