using AutoMapper;
using Core.Domain.Models.AppModels.Dashboard;
using Core.Domain.Models.DTO.Response;
using Core.Domain.Models.ViewModels;
using Core.Domain.Models.ViewModels.DashBoard;
using Core.Domain.Models.ViewModels.User;
using Elmah;
using Infrastructure.Helpers.Enums;
using Infrastructure.Helpers.Security;
using Infrastructure.Resources.Validations.English;
using PagedList;
using Services.InterFaces.ICoreService.IFile;
using Services.InterFaces.ICoreService.IMailInbox;
using Services.InterFaces.ICoreService.IUser;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnitOfWork.Data.IUnitOfWork;

namespace EmailServices.Areas.Managment.Controllers
{
    [Authorize]
    public class DashBoardManagementController : Controller
    {
        #region Conatiners 
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailInboxService _mailInboxService;
        private readonly IFileService _fileService;
        #endregion

        #region Ctor
        public DashBoardManagementController(IUserService userService, IFileService fileService, IMailInboxService mailInboxService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mailInboxService = mailInboxService;
            _fileService = fileService;
        }
        #endregion

        #region Services

        [HttpGet]
        public async Task<ActionResult> GetInboxesByUserEmail(UserViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email))
                {
                    var inboxes = await _mailInboxService.GetCurrentUserInboxes(await _userService.GetUserByEmail(User.Identity.Name));
                    return inboxes.Any() ? PartialView("_DashBord", inboxes.ToPagedList((int)Paging.pageNumber, (int)Paging.PageSize)) : PartialView("_NodataFound"); 
                }
                var user = await _userService.GetUserByEmail(model.Email);
                if (user is null)
                    return PartialView("_NodataFound");

                var userInboxes = await _mailInboxService.GetUserInboxes(user, await _userService.GetUserByEmail(User.Identity.Name));
                if (userInboxes.Any())
                    return PartialView("_DashBord", userInboxes.ToPagedList((int)Paging.pageNumber, (int)Paging.PageSize));

                return PartialView("_NodataFound");

            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> FilterInboxeByType(FilterTypeViewModel model)
        {
            try
            {
                var inboxes = await _mailInboxService.FilterInboxesByType(int.Parse(model.Type), await _userService.GetUserByEmail(User.Identity.Name));
                if (inboxes.Any())
                    return PartialView("_DashBord", inboxes.ToPagedList((int)Paging.pageNumber, (int)Paging.PageSize));

                return PartialView("_NodataFound");
            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }
        
        [HttpGet]
        public async Task<ActionResult> InboxCard(CardViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.InboxId))
                    return View(new InboxCardViewModel());

                var inbox = Mapper.Map<MailInbox, InboxCardViewModel>(await _mailInboxService.GetInboxById(int.Parse(WebUiUtility.Decrypt(model.InboxId.ToString()))));
                return View(inbox);
            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendNewMail(ComposeViewModel model)
        {
            try
            {
                if (model.Attachment != null)
                {
                    if (_fileService.IsSecureFile(model.Attachment))
                    {
                        var composeInbox = await _mailInboxService.SaveInboxWithAttachment(model);
                        if (composeInbox != null)
                            return Json(new AppViewModel() { Data = model.ComposeUser, Success = true });
                    }
                    return Json(new AppViewModel() { Data = "Not secure File", Success = false });
                }

                var inbox = await _mailInboxService.SaveNewComposeEmail(model);

                return inbox !=null ? Json(new AppViewModel() { Data = model.ComposeUser, Success = true }) : 
                    Json(new AppViewModel() { Data = model.ComposeUser, Success = false });

            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }


        [HttpGet]
        public async Task<ActionResult> FilterSideMenueByType(FilterTypeViewModel model)
        {
            try
            {
                var inboxes = await _mailInboxService.FilterSideMenueByType(int.Parse(model.Type), await _userService.GetUserByEmail(User.Identity.Name));
                if (inboxes.Any())
                    return PartialView("_DashBord", inboxes.ToPagedList((int)Paging.pageNumber, (int)Paging.PageSize));

                return PartialView("_NodataFound");
            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> SaveInboxAsStarred(InboxViewModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.InboxId))
                {
                    var isInboxUpdated = await _mailInboxService.SaveInboxAsStarred(int.Parse(WebUiUtility.Decrypt(model.InboxId.ToString())), model.IsStarted.Equals("true") ? true : false);
                    var inboxes = await _mailInboxService.FilterSideMenueByType((int)MailTypes.Started, await _userService.GetUserByEmail(User.Identity.Name));

                    return isInboxUpdated ?  Json(new StarredViewModel() { Data = model.IsStarted.Equals("true")?
                        ValidationResponses.NotStaredInbox : ValidationResponses.SatredInbox,
                     Success = true, ModelCount = inboxes.Count().ToString()}) 
                    : Json(new AppViewModel() { Data = "", Success = false });
                }

                return Json(new AppViewModel() { Data = "", Success = false });
            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteInbox(InboxViewModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.InboxId))
                {
                    var isDeleted = await _mailInboxService.RemoveInboxById(int.Parse(WebUiUtility.Decrypt(model.InboxId.ToString())));
                    return isDeleted ? Json(new AppViewModel() { Data = "Deleted", Success = true }) : Json(new AppViewModel() { Data = "", Success = false });
                }

                return Json(new AppViewModel() { Data = "", Success = false });
            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        #endregion

    }
}