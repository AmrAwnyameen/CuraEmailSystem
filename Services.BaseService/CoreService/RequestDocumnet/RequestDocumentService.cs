using Core.Domain.Models.AppModels;
using Core.Domain.Models.AppModels.AttachementInfo;
using Services.InterFaces.ICoreService.IRequestDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.RequestDocumnet
{
    public class RequestDocumentService : AppService<l_document_type>, IRequestDocumnetService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestDocumentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ChekFilesCodes(List<AttachmentFile> attachmentFiles)
        {
            foreach (var file in attachmentFiles)
            {
                var code = Convert.ToDecimal(file.AttachmentCode);
                if (!Any(s=> s.id == code))
                    return false;
            }

            return true;
        }
    }
}
