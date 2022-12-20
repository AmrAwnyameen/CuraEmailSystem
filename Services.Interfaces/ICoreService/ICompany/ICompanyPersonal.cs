using Core.Domain.Models.AppModels.CompanyInfo;
using Core.Domain.Models.DTO.CompanyPersonals;
using Core.Domain.Models.DTO.RequestDto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.ICompany
{
    public interface ICompanyPersonal : IAppService<CompanyPersonal>
    {
        Task<Dictionary<string,string>> AddInfoAgentInfo(string authorizationNumber, string letter, string year, string documentationOffice);
        Task<Dictionary<string, string>> AddInfoAuthorizedInfo(string CommericalRegister, string Office, string CompanyName);
        Task<Tuple<int, string>> CheckCharchterInfoAgent(Dictionary<string, string> agentInfo);
        Task<Tuple<int, string>> CheckCharchterInfoAuthorized(Dictionary<string, string> authorizedInfo);

        Task<CompanyPersonalsDTO> MapCompanyPersonalsOrchardsDTO(OrchardsRequestDTO orchardsRequestDTO);

        Task<CompanyPersonalsDTO> MapCompanyPersonalsFarmsDTO(FarmsRequestDTO farmsRequestDTO);
    }
}
