using Core.Domain.Context;
using Core.Interfaces.IRepository;
using Infrastructure.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Services.BaseService;
using Services.BaseService.CoreService.Files;
using Services.BaseService.CoreService.Inbox;
using Services.BaseService.CoreService.TrashInbox;
using Services.BaseService.CoreService.User.Information;
using Services.Interfaces.IBaseServices;
using Services.InterFaces.ICoreService.IFile;
using Services.InterFaces.ICoreService.IMailInbox;
using Services.InterFaces.ICoreService.ITrashInbox;
using Services.InterFaces.ICoreService.IUser;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.Data.IUnitOfWork;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace EmailServices
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            #region Identity
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));
            container.RegisterType<IUnitOfWork, UnitOfWork.Data.UnitOfWork.UnitOfWork>();
            container.RegisterType<ApplicationDbContext>(new InjectionConstructor());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<SignInManager<ApplicationUser, string>>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(x => HttpContext.Current.GetOwinContext().Authentication));
            // container.RegisterType<AccountController>(new InjectionConstructor());
            #endregion

            #region AppServices
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IMailInboxService, MailInboxService>();
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IAttachementService, AttachementService>();
            container.RegisterType<IMailAttachmentService, MailAttachmentService>();
            container.RegisterType<ITrashInboxService, TrashInboxService>();
            


            #endregion

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}