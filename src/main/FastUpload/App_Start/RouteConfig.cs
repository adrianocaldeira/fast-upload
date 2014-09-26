using System.Web.Mvc;
using System.Web.Routing;

namespace FastUpload
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Files-Download",
                url: "downloads/{*file}",
                defaults: new { controller = "Files", action = "Download" }
            );

            routes.MapRoute(
                name: "Files-Read",
                url: "{*file}",
                defaults: new {controller = "Files", action = "Read"}
            );
        }
    }
}
