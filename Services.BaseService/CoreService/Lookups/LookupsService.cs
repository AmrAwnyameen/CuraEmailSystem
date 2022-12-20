using Core.Domain.Models.AppModels.LookupInfo;
using Services.InterFaces.ICoreService.ILookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Data.IUnitOfWork;
using System.Data.Entity;
using Infrastructure.Helpers.Enums;
using Services.InterFaces.ICoreService.IRequestDocument;
using Services.InterFaces.ICoreService.IUser;
using Services.InterFaces.ICoreService.IGovernorate;

namespace Services.BaseService.CoreService.Lookups
{
    public class LookupsService : AppService<Lookup>, ILookupsService
    {
        #region Ctor
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestDocumnetService _requestDocumnetService;
        private readonly IUserRequestServiceCodes _userRequestServiceCodes;
        private readonly IRequestDocumnetTypesService _requestDocumnetTypesService;
        private readonly IGovernorateService _governorateService;

        public LookupsService(IUnitOfWork unitOfWork, IGovernorateService governorateService, IRequestDocumnetTypesService requestDocumnetTypesService, IRequestDocumnetService requestDocumnetService, IUserRequestServiceCodes userRequestServiceCodes) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _requestDocumnetService = requestDocumnetService;
            _userRequestServiceCodes = userRequestServiceCodes;
            _requestDocumnetTypesService = requestDocumnetTypesService;
            _governorateService = governorateService;
        }
        #endregion

        #region Services

        public async Task<List<LookupData>> GetByAttcahmentLookupId(int code, int? parentId)
        {
            var results = await _requestDocumnetTypesService.Include(s => s.l_category).Include(s => s.l_document_type)
               .Where(z => z.l_category_id == parentId && z.f_delete == 0).ToListAsync();

            var attchmentsLookups = results.Where(s=> (s.l_document_type_id != (int)LookupsCodesForIsHimSelf.AuthorizationLetter && s.l_document_type_id != (int)LookupsCodesForIsHimSelf.powerofattorney)).Select(s => new LookupData()
            {
                Id = (int)s.l_document_type.id,
                Value = s.l_document_type.DOCTYPENAME
            }).ToList();
            return attchmentsLookups;
        }
        public async Task<List<LookupData>> GetByServiceLookupId(int code)
        {
            var services = await _userRequestServiceCodes.GetAll().ToListAsync();
            var results = services.
             Select(s => new LookupData()
             {
                 Id = (int)s.id,
                 Value = s.ANAME
             }).ToList();

            return results;
        }
        public async Task<Lookup> GetByLookupIdAsync(int code)
        {
            return await Include(x => x.LookupDatas).Where(x => x.Id == code)?.FirstOrDefaultAsync();
        }
        public async Task<ICollection<LookupData>> AddSlugAttachments(List<LookupData> lookupData)
        {
            lookupData.Add(new LookupData() { Id = (int)AttchmentsByCharchter.AttorneyAttchments, Value = Infrastructure.Resources.Validations.Arabic.Ar_Responses.AttorneyAttchments });
            lookupData.Add(new LookupData() { Id = (int)AttchmentsByCharchter.Authorizationletter, Value = Infrastructure.Resources.Validations.Arabic.Ar_Responses.Authorizationletter });
            return lookupData;
        }
        public async Task<IList<LookupData>> GovernoratesLookups()
        {
            var services = await _governorateService.GetAll().ToListAsync();
            return services.
               Select(s => new LookupData()
               {
                   Id = s.Id,
                   Value = s.description
               }).ToList();

        }
        public async Task<Tuple<int, string>> CheckIntegrityForFarmsInformations(string propertyType, string requestType, string activityType)
        {
            if (!string.IsNullOrEmpty(propertyType))
            {
                if (!int.TryParse(propertyType, out _))
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, LookupsFarmCodes.PropertyType.ToString());
                
                var propertyId = int.Parse(propertyType);
                if (await _unitOfWork.Repository<LookupData>().Where(x => x.LookupId == (int)LookupsFarmCodes.PropertyType && x.Id == propertyId)?.FirstOrDefaultAsync() == null)
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, LookupsFarmCodes.PropertyType.ToString());
                
            }
            if (!string.IsNullOrEmpty(requestType))
            {
                if (!int.TryParse(requestType, out _))
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, LookupsFarmCodes.RequestType.ToString());
                
                var prequestTypeId = int.Parse(requestType);
                if (await _unitOfWork.Repository<LookupData>().Where(x => x.LookupId == (int)LookupsFarmCodes.RequestType && x.Id == prequestTypeId)?.FirstOrDefaultAsync() == null)
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, LookupsFarmCodes.RequestType.ToString());
                
            }
            if (!string.IsNullOrEmpty(activityType))
            {
                if (!int.TryParse(activityType, out _))
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, LookupsFarmCodes.ActivityType.ToString());
             
                var activityTypeId = int.Parse(activityType);
                if (await _unitOfWork.Repository<LookupData>().Where(x => x.LookupId == (int)LookupsFarmCodes.ActivityType && x.Id == activityTypeId)?.FirstOrDefaultAsync() == null)
                    return new Tuple<int, string>((int)RequestRequiremenstMessage.notValid, LookupsFarmCodes.ActivityType.ToString());
               
            }
            return new Tuple<int, string>((int)RequestRequiremenstMessage.valid, string.Empty);
        }
        public string GetLookupsSpecificValue(string item)
        {
            if (int.TryParse(item, out _) && int.Parse(item) > 0)
            {
                var validId = int.Parse(item);
                return _unitOfWork.Repository<LookupData>().Where(x => x.Id == validId)?.FirstOrDefaultAsync().Result?.Value;

            }
            return string.Empty;


        }
        public async Task<bool> CheckFarmPropertyValidations(string slug)
        {
            var slugs = new List<string>() { "MALR-02", "MALR-03", "MALR-05", "MALR-13", "MALR-14", "MALR-16" };
            return slugs.Any(s => s.Equals(slug)) ? true : false;
        }

        public async Task<bool> CheckLookupCode(int? code)
        {
            return !Enum.IsDefined(typeof(LookupsCodes), code) ? false : true;
        }
        #endregion

    }
}
