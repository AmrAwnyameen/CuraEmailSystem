using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.AttachementInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IRequestDocument
{
    public interface IRequestDocumnetService : IAppService<l_document_type>
    {

        bool ChekFilesCodes(List<AttachmentFile> attachmentFiles);
    }
}
