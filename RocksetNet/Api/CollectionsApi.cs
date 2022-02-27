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
    public class CollectionsApi : RocksetApi
    {
        public CollectionsApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }

        #region Collection Functions
        /// <summary>
        /// Create new collection in a workspace.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="collection">CreateCollection object containing name (required) as well as collection information</param>
        public async Task<CollectionResponse> Create(string workspace, CreateCollection collection)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/collections")
                    .PostJsonAsync(collection)
                    .ReceiveJson<CollectionResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }

        }

        /// <summary>
        /// Delete a collection and all its documents from Rockset.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="collection">Name of the collection</param>
        public async Task<int> Delete(string workspace, string collection)
        {
            try
            {
                var response = await _client.Request($"/v1/orgs/self/ws/{workspace}/collections/{collection}")
                 .DeleteAsync();
                return response.StatusCode;
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }

        }
        /// <summary>
        /// Get details about a collection.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="collection">Name of the collection</param>
        public async Task<CollectionResponse> Get(string workspace, string collection)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/collections/{collection}")
                    .GetJsonAsync<CollectionResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Retrieve all collections in an organization.
        /// </summary>
        /// <param name="workspace">Name of the workspace. If null or empty, will retrieve all collections in organization</param>
        public async Task<CollectionResponses> List()
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/collections")
                               .GetJsonAsync<CollectionResponses>();

            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }

        }

        /// <summary>
        /// Retrieve all collections in a workspace
        /// </summary>
        /// <param name="workspace">Name of the workspace. If null or empty, will retrieve all collections in organization</param>
        public async Task<CollectionResponses> List(string workspace)
        {
            try
            {

                return await _client.Request($"/v1/orgs/self/ws/{workspace}/collections")
                              .GetJsonAsync<CollectionResponses>();

            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }

        }
        #endregion
    }
}
