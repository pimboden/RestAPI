using System.Web.Http;
using System.Web.Http.Cors;
using Campus.Libs.IoC;

namespace Campus.SOPMobilityOnline.RestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var corsPolicyFactory = DependencyContainer.Resolve<ICorsPolicyProviderFactory>();
            config.SetCorsPolicyProviderFactory(corsPolicyFactory);
            config.EnableCors();
        }
    }
}
