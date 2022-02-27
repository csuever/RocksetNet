using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Api
{
    public class ApiKeyApi : RocksetApi
    {
        public ApiKeyApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }
        #region ApiKey Functions
        /// <summary>
        /// Create a new API key for the authenticated user.
        /// </summary>
        /// <param name="key">ApiKey object containing name (required) and role (optional)</param>
        public async Task<CollectionResponse> Create(ApiKey key)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users/self/apikeys")
                    .PostJsonAsync(key)
                    .ReceiveJson<CollectionResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Delete an API key for any user in your organization.
        /// </summary>
        /// <param name="user">Email of the API key owner. Use self to specify the currently authenticated use</param>
        /// <param name="name">Name of the API key</param>
        public async Task<ApiKeyResponse> Delete(string user, string name)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users/{user}/apikeys/{name}")
               .DeleteAsync()
               .ReceiveJson<ApiKeyResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// List API key metadata for any user in your organization.
        /// </summary>
        /// <param name="user">Email of the API key owner. Use self to specify the currently authenticated use</param>
        public async Task<ApiKeyResponses> List(string user)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users/{user}/apikeys")
                               .GetJsonAsync<ApiKeyResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Retrieve a particular API key for any user in your organization.
        /// </summary>
        /// <param name="user">Email of the API key owner. Use self to specify the currently authenticated use</param>
        /// <param name="name">Name of the API key</param>
        public async Task<ApiKeyResponse> Get(string user, string name)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users/{user}/apikeys/{name}")
                               .GetJsonAsync<ApiKeyResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Update the state of an API key for any user in your organization.
        /// </summary>
        /// <param name="user">Email of the API key owner. Use self to specify the currently authenticated use</param>
        /// <param name="key">API key object containing name (required) and state (optional)</param>
        public async Task<ApiKeyResponse> Update(string user, ApiKey key)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users/{user}/apikeys/{key.Name}")
                    .PostJsonAsync(key)
                    .ReceiveJson<ApiKeyResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        #endregion
    }
}
