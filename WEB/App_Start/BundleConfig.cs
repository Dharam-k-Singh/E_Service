using System.Web;
using System.Web.Optimization;

namespace WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new Bundle("~/bundles/main-css").Include(
                        "~/new/css/bootstrap.min.css",
                        "~/new/css/font-awesome.min.css",
                        "~/new/css/datepicker3.css",
                        "~/css/new/css/styles.css",
                        "~/js/ConfirmJS/css/jquery-confirm.css"
                         ));

            bundles.Add(new Bundle("~/bundles/main-js").Include(
                "~/Scripts/jquery-3.4.1.min.js",
              
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/custom/validation/customValidationMethods.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/UploadFileValidation.js",
                "~/Scripts/Custom/sweetalert2/sweetalert2.all.min.js",
         
                "~/Scripts/custom/multiselect/collapse-multiselect.js",
                "~/Scripts/custom/sweetAlertMethods.js",
                "~/js/ConfirmJS/js/jquery-confirm.js"               
                ));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //             "~/Scripts/jquery.validate*",
            //            "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"
            // ));

            //bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
            //          "~/Scripts/materialize/materialize.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/materialize/css/materialize.css",
            //          "~/Content/site.css"));
        }
    }
}
