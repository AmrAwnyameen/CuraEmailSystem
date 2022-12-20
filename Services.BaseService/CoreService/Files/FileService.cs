using Core.Domain.Models.AppModels.Dashboard;
using Services.InterFaces.ICoreService.IFile;
using System.Configuration;
using System.IO;
using System.Web;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Files
{
    public class FileService : AppService<MailAttachment>, IFileService
    {
        #region Service
        public FileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public bool IsSecureFile(HttpPostedFileBase file)
        {
            return Infrastructure.Helpers.Security.MimeFileValidations.IsValidContetntType(file);
        }
        public void UplaodFile(HttpPostedFileBase file, string directory)
        {
            string fileName = Path.GetFileName(file.FileName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string _path = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["Path"].ToString() + fileName);
            file.SaveAs(_path);
        }
        #endregion
    }
}
