using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain.Models.AppModels.Dashboard;
using Core.Domain.Models.AppModels.Logging;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Core.Domain.Context
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

   
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.MailInboxForm = new HashSet<MailInbox>();
            this.MailInboxTo = new HashSet<MailInbox>();
            this.TrashInboxes = new HashSet<TrashInboxes>();
        }
        public string RecoveryEmail { get; set; }
        public bool verified { get; set; }


        #region EntityMapping

        [InverseProperty(nameof(MailInbox.FromUser))]
        public ICollection<MailInbox> MailInboxForm { get; set; }

        [InverseProperty(nameof(MailInbox.ToUser))]
        public ICollection<MailInbox> MailInboxTo { get; set; }

        public ICollection<TrashInboxes> TrashInboxes { get; set; }

        #endregion
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        #region ModelCreating
        public virtual DbSet<RequestsLogger> RequestsLoggers { get; set; }
        public virtual DbSet<MailType> MailTypes  { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

      

        #endregion


    }
}
