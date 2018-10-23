using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;
using Campus.Libs.IoC;
using Campus.SOPMobilityOnline.RestApi.Helpers;

namespace Campus.SOPMobilityOnline.RestApi
{
    public class CorsPolicyProvider : ICorsPolicyProvider
    {
        private readonly CorsPolicy _policy;

        public CorsPolicyProvider()
        {
            // Create a CORS policy.
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };
            _policy.Headers.Add("accept");
            _policy.Headers.Add("content-type");
            _policy.Headers.Add("origin");

            _policy.Methods.Add("POST");
            _policy.Methods.Add("PUT");
            _policy.Methods.Add("GET");
            _policy.Methods.Add("DELETE");
            _policy.Methods.Add("PATCH");

            AddOrigins(_policy);

            _policy.ExposedHeaders.Add("Date");
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }

        private void AddOrigins(CorsPolicy policy)
        {
            var configuration = DependencyContainer.Resolve<IConfiguration>();
            var origins = configuration.CorsOrigins;
            foreach (var origin in origins)
            {
                _policy.Origins.Add(origin);
            }
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request)
        {
            return Task.FromResult(_policy);
        }
    }
}