using System.Web.Optimization;

namespace FastUpload
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/scripts/bundle").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.knob.js",
                "~/Scripts/jquery.ui.widget.js",
                "~/Scripts/jquery.iframe-transport.js",
                "~/Scripts/jquery.fileupload.js",
                "~/Scripts/fastupload.js"));
            #endregion

            #region Styles
            bundles.Add(new StyleBundle("~/content/fastupload-bundle").Include(
                "~/Content/fastupload.css"));
            #endregion

            BundleTable.EnableOptimizations = false;
        }
    }
}