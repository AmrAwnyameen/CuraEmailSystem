using Elmah;
using Infrastructure.Helpers.Logger;
using Services.InterFaces.ICoreService.IUser;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnitOfWork.Data.IUnitOfWork;

namespace EmailServices.Areas.Managment.Controllers
{
    [Authorize]
    [LogAction]
    public class UserManagmentController : Controller
    {
        #region Conatiner
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public UserManagmentController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Services

        public async Task<JsonResult> GetUsersByEmail(string text)
        {
            try
            {
                var users = await _userService.SearchByEmail(text);
                return Json(users, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
                return Json(false, JsonRequestBehavior.AllowGet);
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

