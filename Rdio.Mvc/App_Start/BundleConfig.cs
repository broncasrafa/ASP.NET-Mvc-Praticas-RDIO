using System.Web;
using System.Web.Optimization;

namespace Rdio.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/album").Include("~/css/plugin/album/simple-line-icons.min.css",
                                                                   "~/css/plugin/album/bootstrap-switch.min.css",
                                                                   "~/css/plugin/album/cubeportfolio.css",
                                                                   "~/css/plugin/album/components-md.min.css",
                                                                   "~/css/plugin/album/plugins-md.min.css",
                                                                   "~/css/plugin/album/portfolio.min.css",
                                                                   "~/css/plugin/album/layout.min.css",
                                                                   "~/css/plugin/album/darkblue.min.css",
                                                                   "~/css/plugin/album/custom.min.css"));
        }
    }
}