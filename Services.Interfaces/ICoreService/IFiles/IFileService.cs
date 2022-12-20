using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.AttachementInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IFiles
{
    public interface IFileService : IAppService<AttachmentFile>
    {
        Task<List<requests_documents>> SaveUserFiles(List<AttachmentFile> files, decimal requestId, string coorNumber);

        Task<string> ConvertFromBase64ToBdf(string attchment ,string coorNumber, string fileName, string fileExtension);

        Task<Tuple<bool,string>> IsFilesSizeValid(List<AttachmentFile> files);

        Task<requests> UpdateRequestFolderPath(requests requests);

        Task<bool> IntegrityUploadStatus(requests request);


    }
}
