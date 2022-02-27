using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class ViewsApi : RocksetApi
    {
        public ViewsApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }
        #region View Functions
        /// <summary>
        /// Create a view
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="view">View data</param>
        public async Task<ViewResponse> Create(string workspace, View view)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/views")
                    .PostJsonAsync(view)
                    .ReceiveJson<ViewResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Delete a view
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="view">Name of the view</param>
        public async Task<int> Delete(string workspace, string view)
        {
            try
            {
                var response = await _client.Request($"/v1/orgs/self/ws/{workspace}/views/{view}")
                 .DeleteAsync();
                return response.StatusCode;
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Retrieve all views in an organization or in a workspace
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        public async Task<ViewResponses> List()
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/views")
                       .GetJsonAsync<ViewResponses>();

            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Retrieve all views in an organization or in a workspace
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        public async Task<ViewResponses> List(string workspace)
        {
            try
            {

                return await _client.Request($"/v1/orgs/self/ws/{workspace}/views")
                    .GetJsonAsync<ViewResponses>();

            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Get details about a view
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="view">Name of the view</param>
        public async Task<ViewResponse> Get(string workspace, string view)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/views/{view}")
                               .GetJsonAsync<ViewResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Update a view
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="view">View data</param>
        public async Task<ViewResponse> Update(string workspace, View view)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/views/{view.Name}")
                    .PostJsonAsync(view)
                    .ReceiveJson<ViewResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        #endregion
    }
}
