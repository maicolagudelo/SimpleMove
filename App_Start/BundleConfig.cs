using System.Web;
using System.Web.Optimization;

namespace SimpleMove
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/scripts.js",
                      "~/Content/js/jquery-3.1.1.min.js",
                      "~/Content/js/sweetalert2.min.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/material.min.js",
                      "~/Content/js/ripples.min.js",
                      "~/Content/js/jquery.mCustomScrollbar.concat.min.js",
                      "~/Content/js/main.js",
                      "~/Content/js/main2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/styles.css"));

            bundles.Add(new StyleBundle("~/Conten/css").Include(
                      "~/Content/css/main.css"));

            bundles.Add(new StyleBundle("~/Contentlogin/css").Include(
                      "~/Content/css/main2.css",
                      "~/Content/css/util.css",
                      "~/Content/css/font-awesome-4.7.0/css/font-awesome.min.css"));
        }
    }
}

