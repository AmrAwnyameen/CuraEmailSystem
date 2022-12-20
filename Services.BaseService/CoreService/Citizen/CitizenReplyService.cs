using Core.Domain.Models.AppModels;
using Core.Domain.Models.DTO.Citizen;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.ICitizen;
using Services.InterFaces.ICoreService.ICitizenDocumntDeatils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.Citizen
{
    public class CitizenReplyService : AppService<citizen_reply_details>, ICitizenReplyService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICitizenDocumntDeatilsService _citizenDocumntDeatilsService;
        public CitizenReplyService(IUnitOfWork unitOfWork, ICitizenDocumntDeatilsService citizenDocumntDeatilsService) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _citizenDocumntDeatilsService = citizenDocumntDeatilsService;
        }

        public  List<CitizenDocumentsInquieryDTO> CitizenDocumentsInquiery(List<citizen_reply_required_documents> citizenReplyDocuments)
        {
            return  citizenReplyDocuments.
                         Select(s =>
                         new CitizenDocumentsInquieryDTO { AttachmentCode = (int)s.l_document_type.id, AttachmentName = s.l_document_type.DOCTYPENAME }).ToList();
        }

        public async Task<citizen_reply_details> FindCitizenReply(decimal? citizenReplyId)
        {
            return await FirstOrDefaultAsync(s => s.id == citizenReplyId);
        }

        public async Task<citizen_reply_details> FindCitizenReplyByRequestId(requests request)
        {
            return await FirstOrDefaultAsync(s => s.request_id == request.corr_id && s.CITIZEN_REPLY_REQUIRED_ACTION_ID == (int)CategoryStatus.PaymentRequired);
        }

        public async Task <List<citizen_reply_required_documents>> FindCitizenReplyRequiredDocuments(citizen_reply_details citizenReplyDetails)
        {
            return await _citizenDocumntDeatilsService.Include(s => s.l_document_type).Where(s => s.CITIZEN_REPLY_DETAILS_ID == citizenReplyDetails.id).ToListAsync();
        }
    }
}
