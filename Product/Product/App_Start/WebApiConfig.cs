using System.Web.Http;

namespace Product
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //Enable Cors to allow the frontend to make calls
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "ProductApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
