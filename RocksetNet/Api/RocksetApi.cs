using Flurl.Http;
using RocksetNet.Configuration;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class RocksetApi : IDisposable
    {
        public readonly IFlurlClient _client;
        private RocksetApiConfiguration _configuration;
        public RocksetApi(RocksetApiConfiguration configuration)
        {
            _configuration = configuration;
            _client = new FlurlClient(configuration.BaseUrl);
            _client.WithHeader("Authorization", $"ApiKey {configuration.ApiKey}");            
        }

        public RocksetApiConfiguration GetConfiguration()
        {
            return _configuration;
        }

        public void SetConfiguration(RocksetApiConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
