using System.Web.Optimization;

namespace IdentitySample
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

            bundles.Add(new ScriptBundle("~/bundles/plantilla").Include(
                      "~/Content/assetsPlantilla/js/bootstrap.min.js",
                      "~/Content/assetsPlantilla/js/count-up.min.js",
                      "~/Content/assetsPlantilla/js/glightbox.min.js",
                      "~/Content/assetsPlantilla/js/imagesloaded.min.js",
                      "~/Content/assetsPlantilla/js/isotope.min.js",
                      "~/Content/assetsPlantilla/js/tiny-slider.js",
                      "~/Content/assetsPlantilla/js/wow.min.js",
                      "~/Content/assetsPlantilla/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                      "~/Content/assetsAdmin/vendors/perfect-scrollbar/perfect-scrollbar.min.js",
                      "~/Content/assetsAdmin/vendors/apexcharts/apexcharts.js",
                      "~/Content/assetsAdmin/vendors/sweetalert2/sweetalert2.all.min.js",
                      "~/Content/assetsAdmin/vendors/toastify/toastify.js",
                      "~/Content/assetsAdmin/js/pages/dashboard.js",
                      "~/Content/assetsAdmin/js/bootstrap.bundle.min.js",
                      "~/Content/assetsAdmin/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastify").Include(
                      "~/Content/assetsAdmin/vendors/toastify/toastify.js"));

            bundles.Add(new StyleBundle("~/Content/toastify").Include(
                      "~/Content/assetsAdmin/vendors/toastify/toastify.css"));

            bundles.Add(new StyleBundle("~/Plantilla/css").Include(
                      "~/Content/assetsPlantilla/css/animate.css",
                      "~/Content/assetsPlantilla/css/bootstrap.min.css",
                      "~/Content/assetsPlantilla/css/glightbox.min.css",
                      "~/Content/assetsPlantilla/css/Linelcons-2.0.css",
                      "~/Content/assetsPlantilla/css/main.css",
                      "~/Content/assetsPlantilla/css/tiny-slider.css"));

            bundles.Add(new StyleBundle("~/Admin/css").Include(
                      "~/Content/assetsAdmin/css/bootstrap.css",
                      "~/Content/assetsAdmin/vendors/iconly/bold.css",
                      "~/Content/assetsAdmin/vendors/perfect-scrollbar/perfect-scrollbar.css",
                      "~/Content/assetsAdmin/vendors/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/assetsAdmin/vendors/sweetalert2/sweetalert2.min.css",
                      "~/Content/assetsAdmin/vendors/toastify/toastify.css",
                      "~/Content/assetsAdmin/css/app.css"));

            bundles.Add(new StyleBundle("~/Login/css").Include(
                      "~/Content/assetsAdmin/css/bootstrap.css",
                      "~/Content/assetsAdmin/vendors/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/assetsAdmin/css/app.css",
                      "~/Content/assetsAdmin/css/pages/auth.css"));
        }
    }
}
