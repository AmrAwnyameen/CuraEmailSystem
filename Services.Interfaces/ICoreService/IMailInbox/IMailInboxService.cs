using Core.Domain.Context;
using Core.Domain.Models.AppModels.Dashboard;
using Core.Domain.Models.ViewModels;
using Core.Domain.Models.ViewModels.DashBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.InterFaces.ICoreService.IMailInbox
{
    public interface IMailInboxService : IAppService<MailInbox>
    {

        #region Services
        Task<Tuple<IQueryable<MailInboxViewModel>, string, string, string>> HomeInboxes(ApplicationUser user);

        Task<IEnumerable<MailInboxViewModel>> GetCurrentUserInboxes(ApplicationUser user);

        Task<IEnumerable<MailInbox>> GetCurrentUserInboxesCount(ApplicationUser user);
        Task<IEnumerable<MailInboxViewModel>> GetUserInboxes(ApplicationUser from, ApplicationUser current);

        Task<IEnumerable<MailInboxViewModel>> FilterInboxesByType(int type, ApplicationUser current);
        Task<MailInbox> GetInboxById(int inboxId);

        Task<MailInbox> SaveInboxWithAttachment(ComposeViewModel composeViewModel);

        Task<MailInbox> SaveNewComposeEmail(ComposeViewModel composeViewModel);

        Task<IEnumerable<MailInboxViewModel>> FilterSideMenueByType(int type, ApplicationUser current);

        Task<bool> RemoveInboxById(int id);

        Task<bool> SaveInboxAsStarred(int id, bool isStarted);
        #endregion

    }
}
