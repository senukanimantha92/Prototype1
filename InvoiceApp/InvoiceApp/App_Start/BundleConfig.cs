using System.Web;
using System.Web.Optimization;

namespace InvoiceApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                       "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/plugins/jquery.steps.min.js",
                        "~/Scripts/plugins/moment.min.js",
                        "~/Scripts/plugins/icheck.min.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/plugins/jquery.nicescroll.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/jquery.number.min.js",
                        "~/Scripts/numeral/numeral.min.js",
                        "~/Scripts/numeral/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/plugins/font-awesome.min.css",
                      "~/Content/plugins/simple-line-icons.css",
                      "~/Content/plugins/animate.min.css",
                      "~/Content/plugins/icheck/skins/flat/aero.css",
                      "~/Content/plugins/jquery.steps.css",
                      "~/Content/plugins/fullcalendar.min.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/toastr.min.css"));
            
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
