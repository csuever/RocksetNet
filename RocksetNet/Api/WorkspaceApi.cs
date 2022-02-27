using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class WorkspaceApi : RocksetApi
    {
        public WorkspaceApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }
        #region Workspace Functions
        /// <summary>
        /// Create a new workspace
        /// </summary>
        /// <param name="workspace">Workspace data</param>
        public async Task<WorkspaceResponse> Create(Workspace workspace)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws")
                    .PostJsonAsync(workspace)
                    .ReceiveJson<WorkspaceResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Delete a new workspace
        /// </summary>
        /// <param name="workspace">Name of a workspace</param>
        public async Task<int> Delete(string workspace)
        {
            try
            {
                var response = await _client.Request($"/v1/orgs/self/ws/{workspace}")
                 .DeleteAsync();
                return response.StatusCode;
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// List all workspaces in an organization.
        /// </summary>
        /// <param name="acrossRegion">Fetch workspaces across regions</param>
        public async Task<WorkspaceResponses> List(bool acrossRegion = false)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws")
                    .SendJsonAsync(HttpMethod.Get, new { fetch_across_region = acrossRegion })
                    .ReceiveJson<WorkspaceResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// List workspaces under given workspace.
        /// </summary>
        public async Task<WorkspaceResponses> List(string workspace)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}")
                    .GetJsonAsync<WorkspaceResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Get information about a single workspace.
        /// </summary>
        /// <param name="workspace">Name of a workspace</param>
        public async Task<WorkspaceResponse> Get(string workspace)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}")
                    .GetJsonAsync<WorkspaceResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        #endregion
    }
}
