using System.Web;
using System.Web.Optimization;

namespace HoloXPLOR
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie-{version}.js"));

            // bundles.Add(new ScriptBundle("~/Content/jqueryval").Include(
            //             "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/Content/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.ui.touch-punch-0.2.3.js"));

            // bundles.Add(new ScriptBundle("~/Content/aframe").Include(
            //             "~/Scripts/aframe-{version}.js"));

            bundles.Add(new ScriptBundle("~/Content/formstone").Include(
                        "~/Scripts/formstone.core-{version}.js",
                        "~/Scripts/formstone.upload-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Content/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Content/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Content/holoxplor").Include(
                        "~/Scripts/holoxplor.*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/site.css"));

#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
