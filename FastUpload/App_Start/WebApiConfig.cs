using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace FastUpload
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings = {ContractResolver = new CamelCasePropertyNamesContractResolver()}
            });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
