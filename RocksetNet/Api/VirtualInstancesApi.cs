using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class VirtualInstancesApi : RocksetApi
    {
        public VirtualInstancesApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }

        #region Virtual Instances Functions
        /// <summary>
        /// Retrieve all virtual instances in an organization.
        /// </summary>
        public async Task<VirtualInstanceResponses> ListVirtualInstances()
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/virtualinstances")
                    .GetJsonAsync<VirtualInstanceResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Get details about a virtual instance.
        /// </summary>
        /// <param name="virtualInstanceId">uuid of the virtual instance</param>
        public async Task<VirtualInstanceResponse> GetVirtualInstance(string virtualInstanceId)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/virtualinstances/{virtualInstanceId}")
                               .GetJsonAsync<VirtualInstanceResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Update the properties of a virtual instance.
        /// </summary>
        /// <param name="virtualInstanceId">uuid of the virtual instance</param>
        /// <param name="instance">Instance details</param>
        public async Task<VirtualInstanceResponse> UpdateVirtualInstance(string virtualInstanceId, VirtualInstance instance)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/virtualinstances/{virtualInstanceId}")
                    .PostJsonAsync(instance)
                    .ReceiveJson<VirtualInstanceResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        #endregion
    }
}
