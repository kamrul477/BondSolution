using System.Web.Optimization;

namespace Mvc.BondApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryUi").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bonnet").Include(
                      "~/Scripts/jquery.bonnet*"));


            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                      "~/Scripts/menu.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                    "~/Scripts/customWrittenScript.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
               "~/Scripts/kendo/2015.2.902/kendo.all.js",
               // "~/Scripts/kendo/kendo.timezones.min.js", // uncomment if using the Scheduler
               "~/Scripts/kendo/2015.2.902/kendo.aspnetmvc.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
               //       "~/Content/kendo/2015.2.902/kendo.common.min.css",
               //"~/Content/kendo/2015.2.902/kendo.default.min.css",
               //"~/Content/kendo/2015.2.902/kendo.common-bootstrap.min.css",
               //"~/Content/kendo/2015.2.902/kendo.bootstrap.min.css"
               ));

            //bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
            //   "~/Content/kendo/2015.2.902/kendo.common.css",
            //   "~/Content/kendo/2015.2.902/kendo.default.css",
            //   "~/Content/kendo/2015.2.902/kendo.common-bootstrap.css",
            //   "~/Content/kendo/2015.2.902/kendo.bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/menu/css").Include(
               "~/Content/menuCss.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base")
                .Include("~/Content/themes/base/jquery-ui.min.css", "~/Content/themes/base/datepicker.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Clear all items from the default ignore list to allow minified CSS and JavaScript files to be included in debug mode
            bundles.IgnoreList.Clear();

            // Add back some of the default ignore list rules
            bundles.IgnoreList.Ignore("*.intellisense.js");
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
        }
    }
}
