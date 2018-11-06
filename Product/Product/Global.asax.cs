using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Product.Service;

namespace Product
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Dependency Injection
            IoC.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
