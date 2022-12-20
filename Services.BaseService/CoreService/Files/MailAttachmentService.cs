using Core.Domain.Models.AppModels.Dashboard;
using Services.InterFaces.ICoreService.IFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Files
{
   public class MailAttachmentService :AppService<MailAttachment>, IMailAttachmentService
    {
        public MailAttachmentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
