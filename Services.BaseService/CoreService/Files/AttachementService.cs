using Core.Domain.Models.AppModels.Dashboard;
using Services.InterFaces.ICoreService.IFile;
using System.IO;
using System.Web;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Files
{
    public class AttachementService : AppService<Attachment>, IAttachementService
    {
        #region Ctor
        public AttachementService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        #endregion
    }
}
