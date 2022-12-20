using Core.Domain.Context;
using Core.Domain.Models.AppModels.Logging;
using Elmah;
using System;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Infrastructure.Helpers.Logger
{
    public class LogActionAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (ApplicationDbContext _context = new ApplicationDbContext())
                    {
                        var serializer = new JavaScriptSerializer();
                        _context.RequestsLoggers.Add(new RequestsLogger
                        {
                            Date = DateTime.Now,
                            Action = serializer.Serialize(actionExecutedContext.ActionDescriptor.ActionName),
                            UserId = System.Web.HttpContext.Current.User.Identity.Name
                        });
                        _context.SaveChanges();
                        ts.Complete();
                    }
                }

            }
            catch (Exception ex)
            {

                Elmah.ErrorLog.GetDefault(null).Log(new Error(ex));
            }
        }

    }
}
