using Core.Domain.Models.AppModels;
using Core.Domain.Models.DTO.Citizen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.ICitizen
{
    public interface ICitizenReplyService : IAppService<citizen_reply_details>
    {
        Task<List<citizen_reply_required_documents>> FindCitizenReplyRequiredDocuments(citizen_reply_details citizen_Reply_Details);

        Task<citizen_reply_details> FindCitizenReply(decimal? citizenReplyId);

        List<CitizenDocumentsInquieryDTO> CitizenDocumentsInquiery(List<citizen_reply_required_documents> citizen_Reply_Required_Documents);


        Task<citizen_reply_details> FindCitizenReplyByRequestId(requests request);
    }
}
