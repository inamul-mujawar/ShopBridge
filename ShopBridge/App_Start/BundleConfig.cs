using System.Web;
using System.Web.Optimization;

namespace ShopBridge
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css-vendor-bundle").Include(
                                        "~/Assets/Vendor/bootstrap/css/bootstrap.min.css",
                                        "~/Assets/Vendor/bootstrap-5.2.0-beta1-dist/css/bootstrap.min.css",
                                        "~/Assets/Vendor/font-awesome-4.7.0/css/font-awesome.min.css",
                                        "~/Assets/CSS/NavBar.css",
                                        "~/Assets/CSS/Footer.css",
                                        "~/Assets/CSS/Global.css",
                                        "~/Assets/CSS/SnackBar.css"
                                        ));
            bundles.Add(new Bundle("~/bundles/bs-jq-bundle").Include(
                                        "~/Assets/Vendor/jquery/jquery.min.js",
                                        //"~/Assets/Vendor/bootstrap/js/bootstrap.min.js"
                                        "~/Assets/Vendor/bootstrap-5.2.0-beta1-dist/js/bootstrap.min.js"
                                        ));

            bundles.Add(new Bundle("~/bundles/datatable-bundle").Include(
                                        "~/Assets/Vendor/DataTables-1.11.5/js/jquery.dataTables.min.js",
                                        "~/Assets/Vendor/DataTables-1.11.5/js/dataTables.bootstrap4.min.js"
                                        ));
        }
    }
}
