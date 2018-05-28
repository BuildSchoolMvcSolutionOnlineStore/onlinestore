using System.Web;
using System.Web.Optimization;

namespace StoreData
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Admin/css").Include(
                     "~/Content/bootstrap.min.css",
                     "~/Content/Admin/styles.css",
                     "~/Content/Admin/datepicker3.css",
                     "~/Content/Admin/font-awesome.min.css"
                   ));

            bundles.Add(new ScriptBundle("~/Admin/jquery").Include(
                      "~/Scripts/Admin/jquery-1.11.1.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/Admin/chart.min.js",
                      "~/Scripts/Admin/chart-data.js",
                      "~/Scripts/Admin/easypiechart.js",
                      "~/Scripts/Admin/easypiechart-data.js",
                      "~/Scripts/Admin/bootstrap-datepicker.js",
                      "~/Scripts/Admin/custom.js"
                      ));
            bundles.Add(new ScriptBundle("~/NewHome/css").Include(
                "~/Content/NewHome/bootstrap.css",
                "~/Content/NewHome/fasthover.css",
                "~/Content/NewHome/flexslider.css",
                "~/Content/NewHome/jquery.countdown.css",
                "~/Content/NewHome/popuo-box.css",
                "~/Content/NewHome/style.css"));
            bundles.Add(new ScriptBundle("~/NewHome/JavaScript").Include(
                "~/Scripts/NewHome/bootstrap-3.1.1.min.js",
                "~/Scripts/NewHome/easyResponsiveTabs.js",
                "~/Scripts/NewHome/imagezoom.js",
                "~/Scripts/NewHome/jquery.countdown.js",
                "~/Scripts/NewHome/jquery.flexisel.js",
                "~/Scripts/NewHome/jquery.flexslider.jg",
                "~/Scripts/NewHome/jquery.magnific-popup.js",
                "~/Scripts/NewHome/jquery.min.js",
                "~/Scripts/NewHome/jquery.wmuSlider.js",
                "~/Scripts/NewHome/script.js",
                "~/Scripts/NewHome/simpleCart.min.js"));
        }
    }
}
