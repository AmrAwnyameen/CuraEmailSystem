namespace Core.Domain.Migrations
{
    using Core.Domain.Models.AppModels.Dashboard;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Core.Domain.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Core.Domain.Context.ApplicationDbContext context)
        {
            context.MailTypes.AddOrUpdate(x => x.Id,
                 new MailType() { Type = "New" },
                 new MailType() { Type = "Sent" },
                 new MailType() { Type = "Starred" },
                 new MailType() { Type = "Trash" }
                 );


        }
    }
}
