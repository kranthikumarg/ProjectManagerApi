using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagerApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var e = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(e);
            config.MapHttpAttributeRoutes();        

            config.Routes.MapHttpRoute(
            name: "swagger_root",
            routeTemplate: "",
            defaults: null,
            constraints: null,
            handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

             
        }
    }
}
