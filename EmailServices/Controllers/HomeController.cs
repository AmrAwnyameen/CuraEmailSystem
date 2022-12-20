using Core.Domain.Models.ViewModels;
using Elmah;
using Infrastructure.Helpers.Enums;
using PagedList;
using Services.InterFaces.ICoreService.IMailInbox;
using Services.InterFaces.ICoreService.IUser;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnitOfWork.Data.IUnitOfWork;

namespace EmailServices.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        #region Conatiners 
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailInboxService _mailInboxService;
        public HomeController(IUserService userService, IUnitOfWork unitOfWork, IMailInboxService mailInboxService)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mailInboxService = mailInboxService;


        }
        #endregion

        #region Services

        public async Task<ActionResult> Inbox()
        {
            try
            {
               var inboxes = await _mailInboxService.HomeInboxes(await _userService.GetUserByEmail(User.Identity.Name));
                SideMenueInboxesCounts(inboxes);
                return View(inboxes.Item1.ToPagedList((int)Paging.pageNumber, (int)Paging.PageSize));
            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        private void SideMenueInboxesCounts(Tuple<IQueryable<MailInboxViewModel>, string, string, string> tuple)
        {
            TempData["InboxCount"] = tuple.Item1.Count();
            TempData["SentItems"] = tuple.Item2;
            TempData["starredItems"] = tuple.Item3;
            TempData["TrashItems"] = tuple.Item4;

        }

        public async Task<ActionResult> HupCheckNewInboxes()
        {
            try
            {
                var current = Session["UserInboxes"];
                if (current != null)
                {
                    var inboxes = await _mailInboxService.GetCurrentUserInboxesCount(await _userService.FirstOrDefaultAsync(s => s.UserName.Equals(User.Identity.Name)));
                    if (inboxes.Count() > (int)current)
                    {
                        Session["UserInboxes"] = inboxes.Count();
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
        #endregion

    }
}