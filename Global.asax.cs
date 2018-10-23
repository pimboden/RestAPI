using System.Globalization;
using System.Net.Http.Formatting;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using Campus.Libs.IoC;
using Campus.SOPMobilityOnline.RestApi;
using Campus.SOPMobilityOnline.RestApi.Helpers;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RestApi
{
    public class WebApiApplication : HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WebApiApplication));
        protected void Application_Start()
        {
            XmlConfigurator.Configure();
            Log.Info("Inititalizig ReST API");

            var ci = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentCulture = ci;

            DependencyContainer.RegisterType<IConfiguration, Configuration>(new LifetimeSingleton());
            DependencyContainer.RegisterType<ICorsPolicyProvider, CorsPolicyProvider>(new LifetimeSingleton());
            DependencyContainer.RegisterType<ICorsPolicyProviderFactory, CorsPolicyFactory>(new LifetimeSingleton());


            GlobalConfiguration.Configure(WebApiConfig.Register);

            // zum resolven der WebAPI Controller via IoC
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new IocCompositionRoot());

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatString = "yyyy-MM-ddTHH:mm:ssZ"
            };
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings = jsonSerializerSettings
            });
        }
    }
}
