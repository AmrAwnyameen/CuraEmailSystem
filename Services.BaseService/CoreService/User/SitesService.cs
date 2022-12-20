using Core.Domain.Models.AppModels.SiteInfo;
using Services.InterFaces.ICoreService.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.User
{
    public class SitesService : AppService<Site>, ISitesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SitesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
