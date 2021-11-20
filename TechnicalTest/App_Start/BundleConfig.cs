using System.Web;
using System.Web.Optimization;

namespace TechnicalTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                    .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                    .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                    .Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css")
                .Include("~/Content/css/bootstrap-select.css")
                .Include("~/Content/css/icheck/blue.min.css")
                .Include("~/Content/css/AdminLTE.css")
                .Include("~/Content/css/skins/skin-blue.css")
                .Include("~/Content/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Scripts/bootstrap.js"));
        }
    }
}
