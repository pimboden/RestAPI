using System.Configuration;

namespace Campus.SOPMobilityOnline.RestApi.Helpers
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
            CorsOrigins = ConfigurationManager.AppSettings["CorsOrigins"].Split(',');
        }

        public string[] CorsOrigins { get; }
    }
}