using Core.Domain.Mapping;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmailServices
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AutoMapperConfig.RegiaterArigMapper();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // I developed app by using sql service broker but
            // Service broker is not available for Azure SQL Database,
            // by Default service puplish way , so  we should choose another option  like
            //Create Azure SQL Managed Instance or azure vm

            //SqlDependency.Start(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        protected void Application_End()
        {
           // SqlDependency.Stop(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        protected void Application_PreSendRequestHeaders()
        {

            Response.AddHeader("X-Frame-Options", "*");

            Response.AppendHeader("Access-Control-Allow-Origin", "*");

            Response.Headers.Remove("X-AspNetMvc-Version");
            Response.Headers.Remove("X-Powered-By");

            Response.Headers.Remove("X-Frame-Options");
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
        }
    }
}
