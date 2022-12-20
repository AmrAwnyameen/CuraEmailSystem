using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmailServices.Startup))]
namespace EmailServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
