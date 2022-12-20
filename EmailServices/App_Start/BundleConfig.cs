using System.Web;
using System.Web.Optimization;

namespace EmailServices
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
            .Include("~/Scripts/jquery-2.1.1.min.js")
              .Include("~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));
            // jQueryUI 
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/plugins/jquery-ui/jquery-ui.min.js"
                ));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                "~/Scripts/plugins/sweetalert/sweetalert.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.js",
                "~/Scripts/Majesty/Bootbox.js",
                "~/Scripts/toastr.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/cs/bootstrap.min.css",
                "~/Content/cs/animate.css",
                "~/Content/cs/style.css",
                "~/Content/cs/sweetalert/sweet-alert.css",
                "~/Content/cs/toastr.css"
            ));

            bundles.Add(new StyleBundle("~/fonts/font-awesome/css/css").Include(
                "~/fonts/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));


            bundles.Add(new StyleBundle("~/Content/kendo/2015.2.902/css").Include(
                "~/Content/kendo/2015.2.902/kendo.common.min.css",
                "~/Content/kendo/2015.2.902/kendo.uniform.min.css"));

            bundles.Add(new ScriptBundle("~/Kendo").Include(
                "~/Scripts/kendo/2015.2.902/jszip.min.js",
                "~/Scripts/kendo/2015.2.902/kendo.all.min.js",
                "~/Scripts/kendo/2015.2.902/kendo.aspnetmvc.min.js",
                "~/Scripts/kendo.modernizr.custom.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
