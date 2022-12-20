using Core.Domain.Models.AppModels.Dashboard;
using System.Web;

namespace Services.InterFaces.ICoreService.IFile
{
    public interface IFileService : IAppService<MailAttachment>
    {
        void UplaodFile(HttpPostedFileBase file ,string path);

        bool IsSecureFile(HttpPostedFileBase file);
    }
}
