using Services.InterFaces.ICoreService.IMailInbox;
using Core.Domain.Models.AppModels.Dashboard;
using UnitOfWork.Data.IUnitOfWork;
using System.Collections.Generic;
using Core.Domain.Context;
using System.Linq;
using Infrastructure.Helpers.Enums;
using Core.Domain.Models.ViewModels;
using System.Threading.Tasks;
using System.Data.Entity;
using Core.Domain.Models.ViewModels.DashBoard;
using Services.InterFaces.ICoreService.IFile;
using System.Configuration;
using Services.InterFaces.ICoreService.IUser;
using System;
using Services.InterFaces.ICoreService.ITrashInbox;

namespace Services.BaseService.CoreService.TrashInbox
{
    public class TrashInboxService : AppService<TrashInboxes>, ITrashInboxService
    {
        public TrashInboxService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
