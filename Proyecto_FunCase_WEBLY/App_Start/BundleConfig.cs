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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Plantilla/css").Include(
                      "~/Content/assetsPlantilla/css/animate.css",
                      "~/Content/assetsPlantilla/css/bootstrap.min.css",
                      "~/Content/assetsPlantilla/css/glightbox.min.css",
                      "~/Content/assetsPlantilla/css/Linelcons-2.0.css",
                      "~/Content/assetsPlantilla/css/main.css",
                      "~/Content/assetsPlantilla/css/tiny-slider.css"));
        }
    }
}
