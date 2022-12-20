using Services.InterFaces.ICoreService.IMailInbox;
using Core.Domain.Models.AppModels.Dashboard;
using UnitOfWork.Data.IUnitOfWork;
using System.Collections.Generic;
using Core.Domain.Context;
using System.Linq;
using Infrastructure.Helpers.Enums;
using Core.Domain.Models.ViewModels;
using System.Threading.Tasks;
using System.Data.Entity;
using Core.Domain.Models.ViewModels.DashBoard;
using Services.InterFaces.ICoreService.IFile;
using System.Configuration;
using Services.InterFaces.ICoreService.IUser;
using System;
using Services.InterFaces.ICoreService.ITrashInbox;
using System.Web;

namespace Services.BaseService.CoreService.Inbox
{
    public class MailInboxService : AppService<MailInbox>, IMailInboxService
    {
        #region Ctor
        private readonly IFileService _fileService;
        private readonly IUserService _userService;
        private readonly IAttachementService _attachementService;
        private readonly IMailAttachmentService _mailAttachmentService;
        private readonly ITrashInboxService _trashInboxService;
        public MailInboxService(IUnitOfWork unitOfWork, ITrashInboxService trashInboxService, IMailAttachmentService mailAttachmentService, IFileService fileService, IUserService userService, IAttachementService attachementService) : base(unitOfWork)
        {
            _fileService = fileService;
            _userService = userService;
            _attachementService = attachementService;
            _mailAttachmentService = mailAttachmentService;
            _trashInboxService = trashInboxService;
        }
        #endregion

        #region Services
        public async Task<IEnumerable<MailInboxViewModel>> GetCurrentUserInboxes(ApplicationUser user)
        {
            return await Where(s => s.ToUserId == user.Id
            && s.MailTypeId == (int)MailTypes.Sent &&
            !s.TrashInboxes.Any(m => m.InboxId == s.Id && m.DeleteBy == user.Id))
                .Select(s => new MailInboxViewModel()
                {
                    Id = s.Id,
                    IsDeleted = s.IsDeleted,
                    Content = s.Content,
                    Date = s.Date,
                    ToUserId = s.ToUserId,
                    FromUserId = s.FromUserId,
                    FromUserName = s.FromUser.UserName,
                    IsRead = s.IsRead != null ? s.IsRead : false,
                    Subject = s.Subject
                }).OrderByDescending(s => s.Date).ToListAsync();
        }

        public async Task<Tuple<IQueryable<MailInboxViewModel>, string, string, string>> HomeInboxes(ApplicationUser user)
        {
            var homeInboxes = Where(s => s.ToUserId == user.Id
           && s.MailTypeId == (int)MailTypes.Sent && !s.TrashInboxes.Any(m => m.InboxId == s.Id && m.DeleteBy == user.Id))
                .Select(s => new MailInboxViewModel()
                {
                    Id = s.Id,
                    IsDeleted = s.IsDeleted,
                    Content = s.Content,
                    Date = s.Date,
                    ToUserId = s.ToUserId,
                    FromUserId = s.FromUserId,
                    FromUserName = s.FromUser.UserName,
                    IsRead = s.IsRead != null ? s.IsRead : false,
                    Subject = s.Subject,
                    IsStarred = s.IsStarred,
                    Type = ((int)MailTypes.New).ToString(),
                    IsAttached = s.mailAttachments.Any() ? true : false
                }).OrderByDescending(s => s.Date);

            var sentInboxeCount = Where(s => !s.TrashInboxes.Any(m => m.InboxId == s.Id && m.DeleteBy == user.Id)
            && s.MailTypeId == (int)MailTypes.Sent && s.FromUserId == user.Id).Count();

            var starredInboxCount = Where(s => !s.TrashInboxes.Any(m => m.InboxId == s.Id && m.DeleteBy == user.Id) &&
            s.IsStarred && s.ToUserId == user.Id).Count();

            var trashInboxCount = _trashInboxService.Where(a => a.DeleteBy == user.Id).Count();

            HttpContext.Current.Session["UserInboxes"] = homeInboxes.Count();
            return new Tuple<IQueryable<MailInboxViewModel>, string, string, string>(homeInboxes, sentInboxeCount.ToString(), starredInboxCount.ToString(), trashInboxCount.ToString());
        }

        public async Task<MailInbox> GetInboxById(int inboxId)
        {
            var inbox = await FirstOrDefaultAsync(s => s.Id == inboxId);
            var user = await _userService.GetUserByEmail(System.Web.HttpContext.Current.User.Identity.Name);
            if (inbox != null)
            {
                inbox.IsRead = true;
                await UpdateAsync(inbox);
                inbox.IsDeleted = _trashInboxService.Any(s => s.InboxId == inbox.Id && s.DeleteBy == user.Id) ? true : false;
            }
            return inbox;
        }

        public async Task<IEnumerable<MailInboxViewModel>> GetUserInboxes(ApplicationUser from, ApplicationUser currentUser)
        {

            var fromInbox = Where(s => s.FromUserId == from.Id
                         && s.ToUserId == currentUser.Id
                         && !s.TrashInboxes.
                         Any(m => m.InboxId == s.Id && m.DeleteBy == currentUser.Id));

            var fromSentInbox = Where(s => s.FromUserId == currentUser.Id
               && s.ToUserId == from.Id
                && !s.TrashInboxes.
                Any(m => m.InboxId == s.Id && m.DeleteBy == currentUser.Id));

            return await fromInbox.Union(fromSentInbox).Select(s => new MailInboxViewModel()
            {
                Id = s.Id,
                IsDeleted = s.IsDeleted,
                Content = s.Content,
                Date = s.Date,
                ToUserId = s.ToUserId,
                FromUserId = s.FromUserId,
                FromUserName = from.UserName,
                IsRead = s.IsRead != null ? s.IsRead : false,
                Subject = s.Subject
            }).OrderByDescending(s => s.Date).ToListAsync();
        }

        public async Task<IEnumerable<MailInboxViewModel>> FilterInboxesByType(int type, ApplicationUser currentUser)
        {

            if (type == (int)InboxFilterType.New || type == (int)InboxFilterType.Old)
            {
                var inboxes = Where(s => s.ToUserId == currentUser.Id
                 && s.ToUserId == currentUser.Id
                 && !s.TrashInboxes.
                 Any(m => m.InboxId == s.Id && m.DeleteBy == currentUser.Id));

                return type == (int)InboxFilterType.New ?
                await inboxes.Select(s => new MailInboxViewModel()
                {
                    Id = s.Id,
                    IsDeleted = s.IsDeleted,
                    Content = s.Content,
                    Date = s.Date,
                    ToUserId = s.ToUserId,
                    FromUserId = s.FromUserId,
                    FromUserName = s.FromUser.UserName,
                    IsRead = s.IsRead != null ? s.IsRead : false,
                    Subject = s.Subject,
                    IsAttached = s.mailAttachments.Any() ? true : false,
                    Type = ((int)MailTypes.New).ToString(),
                    IsStarred = s.IsStarred,
                }).OrderByDescending(s => s.Date).ToListAsync()
              : await inboxes.Select(s => new MailInboxViewModel()

               {
                   Id = s.Id,
                   IsDeleted = s.IsDeleted,
                   Content = s.Content,
                   Date = s.Date,
                   ToUserId = s.ToUserId,
                   FromUserId = s.FromUserId,
                   FromUserName = s.FromUser.UserName,
                   IsRead = s.IsRead != null ? s.IsRead : false,
                   Subject = s.Subject,
                   IsStarred = s.IsStarred,
                   IsAttached = s.mailAttachments.Any() ? true : false,
                   Type = ((int)MailTypes.New).ToString()
               }).OrderBy(s => s.Date).ToListAsync();

            }

            return await Where(s => s.ToUserId == currentUser.Id
            && s.ToUserId == currentUser.Id
            && !s.TrashInboxes.Any(m => m.InboxId == s.Id && m.DeleteBy == currentUser.Id) &&
            (type == (int)InboxFilterType.Read ?
            s.IsRead.Value : (type == (int)InboxFilterType.Unread) ?
            !s.IsRead.Value : s.IsDeleted == false))
            .Select(s => new MailInboxViewModel()
                {
                    Id = s.Id,
                    IsDeleted = s.IsDeleted,
                    Content = s.Content,
                    Date = s.Date,
                    ToUserId = s.ToUserId,
                    FromUserId = s.FromUserId,
                    FromUserName = s.FromUser.UserName,
                    IsRead = s.IsRead != null ? s.IsRead : false,
                    Subject = s.Subject,
                    IsStarred = s.IsStarred,
                    IsAttached = s.mailAttachments.Any() ? true : false,
                    Type = ((int)MailTypes.New).ToString()
                }).OrderByDescending(s => s.Date).ToListAsync();
        }

        public async Task<MailInbox> SaveInboxWithAttachment(ComposeViewModel model)
        {
            var toUser = await _userService.FirstOrDefaultAsync(s => s.Email.Equals(model.ComposeUser));
            var fromUser = await _userService.GetUserByEmail(System.Web.HttpContext.Current.User.Identity.Name);

            var attachment = await _attachementService.AddAsync(new Attachment() { Date = DateTime.Now, Path = string.Concat(ConfigurationManager.AppSettings["Path"].ToString(), "/", model.Attachment.FileName), Name = model.Attachment.FileName });
            var inbox = await AddAsync(new MailInbox() { Content = model.Message, Subject = model.Subject, MailTypeId = (int)MailTypes.Sent, FromUserId = fromUser.Id, IsDeleted = false, IsRead = false, Date = DateTime.Now, ToUserId = toUser.Id });

            var inboxAttachemnt = await _fileService.AddAsync(new MailAttachment() { AttachmentId = attachment.Id, InboxId = inbox.Id });
            _fileService.UplaodFile(model.Attachment, ConfigurationManager.AppSettings["AzurePath"].ToString());
            return inbox;
        }

        public async Task<MailInbox> SaveNewComposeEmail(ComposeViewModel model)
        {
            var toUser = await _userService.FirstOrDefaultAsync(s => s.Email.Equals(model.ComposeUser));
            if (toUser != null)
            {
                var fromUser = await _userService.GetUserByEmail(System.Web.HttpContext.Current.User.Identity.Name);
                var inbox = await AddAsync(new MailInbox()
                {
                    Content = model.Message,
                    Subject = model.Subject,
                    FromUserId = fromUser.Id,
                    IsDeleted = false,
                    IsRead = false,
                    Date = DateTime.Now,
                    ToUserId = toUser.Id,
                    MailTypeId = (int)MailTypes.Sent
                });
                return inbox;
            }
            return null;
        }

        public async Task<IEnumerable<MailInboxViewModel>> FilterSideMenueByType(int type, ApplicationUser current)
        {

            if (type == (int)MailTypes.New)
                return await Where(s => s.MailTypeId ==
                (int)MailTypes.Sent && s.ToUserId == current.Id &&
                !s.TrashInboxes.Any(m => m.InboxId == s.Id && m.DeleteBy == current.Id))
                    .Select(s => new MailInboxViewModel()
                    {
                        Id = s.Id,
                        IsDeleted = s.IsDeleted,
                        Content = s.Content,
                        Date = s.Date,
                        ToUserId = s.ToUserId,
                        FromUserId = s.FromUserId,
                        FromUserName = s.FromUser.UserName,
                        IsRead = s.IsRead != null ? s.IsRead : false,
                        Subject = s.Subject,
                        Type = ((int)MailTypes.New).ToString(),
                        IsStarred = s.IsStarred,
                        IsAttached = s.mailAttachments.Any() ? true : false

                    })
                 .OrderByDescending(s => s.Date).ToListAsync();

            else if (type == (int)MailTypes.Sent)
                return await Where(s => !s.TrashInboxes.Any(m => m.InboxId == s.Id && m.DeleteBy == current.Id) &&
                s.MailTypeId == (int)MailTypes.Sent && s.FromUserId == current.Id)
                    .Select(s => new MailInboxViewModel()
                    {
                        Id = s.Id,
                        IsDeleted = s.IsDeleted,
                        Content = s.Content,
                        Date = s.Date,
                        ToUserId = s.ToUserId,
                        FromUserId = s.FromUserId,
                        ToUserName = s.ToUser.UserName,
                        IsRead = s.IsRead != null ? s.IsRead : false,
                        Subject = s.Subject,
                        IsAttached = s.mailAttachments.Any() ? true : false,
                    })
                .OrderByDescending(s => s.Date).ToListAsync();

            else if (type == (int)MailTypes.Started)
                return await Where(s => !s.TrashInboxes.Any(m => m.InboxId == s.Id && m.DeleteBy == current.Id)
                && s.IsStarred && s.ToUserId == current.Id)
                    .Select(s => new MailInboxViewModel()
                    {
                        Id = s.Id,
                        IsDeleted = s.IsDeleted,
                        Content = s.Content,
                        Date = s.Date,
                        ToUserId = s.ToUserId,
                        FromUserId = s.FromUserId,
                        FromUserName = s.FromUser.UserName,
                        IsRead = s.IsRead != null ? s.IsRead : false,
                        Subject = s.Subject,
                        IsAttached = s.mailAttachments.Any() ? true : false
                    })
                .OrderByDescending(s => s.Date).ToListAsync();

            else return await _trashInboxService.Where(s => s.DeleteBy == current.Id)
                    .Select(s => new MailInboxViewModel()
                    {
                        Id = s.MailInbox.Id,
                        Content = s.MailInbox.Content,
                        Date = s.MailInbox.Date,
                        ToUserId = s.MailInbox.ToUserId,
                        FromUserId = s.MailInbox.FromUserId,
                        FromUserName = s.MailInbox.FromUser.UserName,
                        IsRead = s.MailInbox.IsRead != null ? s.MailInbox.IsRead : false,
                        Subject = s.MailInbox.Subject,
                        Type = s.MailInbox.MailTypeId.ToString()
                    })
            .OrderByDescending(s => s.Date).ToListAsync();

        }

        public async Task<bool> RemoveInboxById(int id)
        {
            var currentUser = await _userService.FirstOrDefaultAsync(s => s.Email.Equals(System.Web.HttpContext.Current.User.Identity.Name));
            var inbox = await FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);
            if (inbox != null)
            {
                var trashInboxe = new TrashInboxes();
                trashInboxe.DeleteBy = currentUser.Id;
                trashInboxe.InboxId = inbox.Id;
                trashInboxe.Date = DateTime.Now;
                await _trashInboxService.AddAsync(trashInboxe);
                return true;
            }
            return false;
        }

        public async Task<bool> SaveInboxAsStarred(int id, bool isStarrted)
        {
            var inbox = await FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);

            if (inbox != null)
            {
                inbox.IsStarred = isStarrted == true ? false : isStarrted == false ? true : false;
                await UpdateAsync(inbox);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<MailInbox>> GetCurrentUserInboxesCount(ApplicationUser user)
        {
            return await Where(s => s.ToUserId == user.Id
                    && s.MailTypeId ==
                    (int)MailTypes.Sent &&
                    !s.TrashInboxes.
                    Any(m => m.InboxId == s.Id && m.DeleteBy == user.Id)).
                    ToListAsync();
        }

        #endregion

    }
}
