using System.Net.Http;
using System.Web.Http.Cors;
using Campus.Libs.IoC;

namespace Campus.SOPMobilityOnline.RestApi
{
    public class CorsPolicyFactory : ICorsPolicyProviderFactory
    {
        private readonly ICorsPolicyProvider _provider =null;

        public CorsPolicyFactory(ICorsPolicyProvider provider)
        {
            _provider = provider;
        }

        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return _provider;
        }
    }
}