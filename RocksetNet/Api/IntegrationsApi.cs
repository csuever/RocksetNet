using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class IntegrationsApi : RocksetApi
    {
        public IntegrationsApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }
        #region Integration Functions
        /// <summary>
        /// Create a new integration.
        /// </summary>
        /// <param name="source">Source object</param>
        public async Task<IntegrationResponse> Create(Source source)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/integrations")
                    .PostJsonAsync(source)
                    .ReceiveJson<IntegrationResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Remove an integration.
        /// </summary>
        /// <param name="integration">Name of the integration</param>
        public async Task<int> Delete(string integration)
        {
            try
            {
                var response = await _client.Request($"/v1/orgs/self/integrations/{integration}")
                 .DeleteAsync();
                return response.StatusCode;
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// List all integrations in an organization.
        /// </summary>
        public async Task<IntegrationResponses> List()
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/integrations")
                               .GetJsonAsync<IntegrationResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Retrieve information about a single integration.
        /// </summary>
        /// <param name="integration">Name of the integration</param>
        public async Task<IntegrationResponse> Get(string integration)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/integrations/{integration}")
                               .GetJsonAsync<IntegrationResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        #endregion
    }
}
