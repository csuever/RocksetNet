using Flurl.Http;
using RocksetNet.Configuration;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Api
{
    public class AliasesApi : RocksetApi
    {
        public AliasesApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }

        #region Alias Functions
        /// <summary>
        /// Create new alias in a workspace.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="alias">Alias object containing name (required), description (optional) and collections (required)</param>
        public async Task<AliasResponse> Create(string workspace, Alias alias)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/aliases")
                    .PostJsonAsync(alias)
                    .ReceiveJson<AliasResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Delete an alias.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="name">Name of the alias</param>
        public async Task<AliasResponse> Delete(string workspace, string name)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/aliases/{name}")
               .DeleteAsync()
               .ReceiveJson<AliasResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Retrieve all aliases in an organization
        /// </summary>
        public async Task<AliasResponses> List()
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/aliases")
                               .GetJsonAsync<AliasResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Retrieve all aliases in a workspace.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        public async Task<AliasResponses> List(string workspace)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/aliases")
                               .GetJsonAsync<AliasResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Update alias in a workspace.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="alias">Alias object</param>
        public async Task<AliasResponse> Update(string workspace, Alias alias)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/aliases/{alias.Name}")
                    .PostJsonAsync(alias)
                    .ReceiveJson<AliasResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Get details about an alias
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="name">Name of the alias</param>
        public async Task<AliasResponse> Get(string workspace, string name)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/aliases/{name}")
                               .GetJsonAsync<AliasResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        #endregion
    }
}
