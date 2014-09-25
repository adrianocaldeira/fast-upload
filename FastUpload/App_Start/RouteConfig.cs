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

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "ViewFile",
                url: "{*file}",
                defaults: new {controller = "Files", action = "Read"}
            );
        }
    }
}
