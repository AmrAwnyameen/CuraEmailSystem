using AutoMapper;
using Core.Domain.Models.AppModels.CompanyInfo;
using Core.Domain.Models.DTO.CompanyPersonals;
using Core.Domain.Models.DTO.RequestDto;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.ICompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;

namespace Services.BaseService.CoreService.ComanyPersonal
{
    public class CompanyPersonalServices : AppService<CompanyPersonal>, ICompanyPersonal
    {

        #region Ctor
        private readonly IUnitOfWork _unitOfWork;
        public CompanyPersonalServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Services
        public async Task<Dictionary<string, string>> AddInfoAgentInfo(string authorizationNumber, string letter, string year, string documentationOffice)
        {
            var agentInfoHash = new Dictionary<string, string>();
            await Task.Run(() =>
            {
                agentInfoHash.Add("AuthorizationNumber", authorizationNumber);
                agentInfoHash.Add("Letter", letter);
                agentInfoHash.Add("Year", year);
                agentInfoHash.Add("DocumentationOffice", documentationOffice);

            });
            return agentInfoHash;
        }

        public async Task<Dictionary<string, string>> AddInfoAuthorizedInfo(string CommericalRegister, string Office, string CompanyName)
        {
            var authorizedInfoHash = new Dictionary<string, string>();
            await Task.Run(() =>
            {
                authorizedInfoHash.Add("CommericalRegister", CommericalRegister);
                authorizedInfoHash.Add("Office", Office);
                authorizedInfoHash.Add("CompanyName", CompanyName);
            });
            return authorizedInfoHash;
        }

        public async Task<Tuple<int, string>> CheckCharchterInfoAgent(Dictionary<string, string> agentInfo)
        {
            if (agentInfo.ContainsValue(string.Empty) || agentInfo.ContainsValue(null))
            {
                var item = agentInfo.Where(s => string.IsNullOrEmpty(s.Value)).FirstOrDefault();
                return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, item.Key + " " + Infrastructure.Resources.Validations.Arabic.Ar_Responses.Required);
            }
            return new Tuple<int, string>((int)RequestRequiremenstMessage.valid, string.Empty);
        }

        public async Task<Tuple<int, string>> CheckCharchterInfoAuthorized(Dictionary<string, string> authorizedInfo)
        {
            if (authorizedInfo.ContainsValue(string.Empty) || authorizedInfo.ContainsValue(null))
            {
                var item = authorizedInfo.Where(s => string.IsNullOrEmpty(s.Value)).FirstOrDefault();
                return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, item.Key + " " + Infrastructure.Resources.Validations.Arabic.Ar_Responses.Required);
            }
            return new Tuple<int, string>((int)RequestRequiremenstMessage.valid, string.Empty);
        }

        public async Task<CompanyPersonalsDTO> MapCompanyPersonalsOrchardsDTO(OrchardsRequestDTO model)
        {
            return Mapper.Map<OrchardsRequestDTO, CompanyPersonalsDTO>(model);
        }

        public async Task<CompanyPersonalsDTO> MapCompanyPersonalsFarmsDTO(FarmsRequestDTO model)
        {
            return Mapper.Map<FarmsRequestDTO, CompanyPersonalsDTO>(model);
        }
        #endregion

    }
}
