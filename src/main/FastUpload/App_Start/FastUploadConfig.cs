using System.Collections.Generic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Newtonsoft.Json;
using Owin;

[assembly: OwinStartup(typeof(FastUpload.FastUploadConfig))]
namespace FastUpload
{
    public class FastUploadConfig
    {
        public void Configuration(IAppBuilder app)
        {
            RouteConfig();
            BundleConfig();
            ContentyTypeConfig();
        }

        private static void RouteConfig()
        {
            if (RouteTable.Routes["Default"] != null)
            {
                RouteTable.Routes.Remove(RouteTable.Routes["Default"]);
            }
            RouteTable.Routes.LowercaseUrls = true;
            RouteTable.Routes.MapMvcAttributeRoutes();
            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            RouteTable.Routes.MapRoute(
                name: "Files-Download",
                url: "downloads/{*file}",
                defaults: new {controller = "Files", action = "Download"}
                );
            RouteTable.Routes.MapRoute(
                name: "Files-Read",
                url: "{*file}",
                defaults: new {controller = "Files", action = "Read"}
                );
        }

        private static void ContentyTypeConfig()
        {
            ContentType.Types = JsonConvert.DeserializeObject<List<ContentType>>(
                System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/App_Data/ContentTypes.json")));
        }

        private static void BundleConfig()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/scripts/fastupload-bundle").Include(
                "~/Scripts/String.js",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.knob.js",
                "~/Scripts/jquery.ui.widget.js",
                "~/Scripts/jquery.iframe-transport.js",
                "~/Scripts/jquery.fileupload.js",
                "~/Scripts/fastupload.js"));

            BundleTable.Bundles.Add(new StyleBundle("~/content/fastupload-bundle").Include(
                "~/Content/fastupload.css"));
        }
    }
}