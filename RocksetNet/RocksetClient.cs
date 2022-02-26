using Flurl;
using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;

namespace RocksetNet
{
    public enum Region
    {
        USWest,
        USEast,
        EUCentral
    }
    public class RocksetClient : IRocksetClient, IDisposable
    {
        public string _apiKey { get; private set; }
        public string _baseUrl { get; private set; }
        private readonly IFlurlClient _client;
        /// <summary>
        /// Initializes a <see cref="RocksetClient"/>.
        /// </summary>
        /// <param name="apiKey">API key used to authenticate requests</param>
        /// <param name="region">Region of your organization</param>
        public RocksetClient(string apiKey, Region region)
        {
            _apiKey = apiKey;
            switch (region)
            {
                case Region.USWest:
                    _baseUrl = "https://api.rs2.usw2.rockset.com";
                    break;
                case Region.USEast:
                    _baseUrl = "https://api.use1a1.rockset.com";
                    break;
                case Region.EUCentral:
                    _baseUrl = "https://api.euc1a1.rockset.com";
                    break;
            }
            _client = new FlurlClient(_baseUrl);
            _client.WithHeader("Authorization", $"ApiKey {_apiKey}");
        }

        /// <summary>
        /// Validate a SQL query with Rockset's parser and planner..
        /// </summary>
        /// <param name="sql"><see cref="SQL"/> Main query request body.</param>
        public async Task<QueryResponse> Query(SQL sql)
        {
            try
            {
                return await _client.Request("/v1/orgs/self/queries")
                .PostJsonAsync(new
                {
                    sql = sql
                })
                .ReceiveJson<QueryResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }

        }

        /// <summary>
        /// Make a SQL query to Rockset.
        /// </summary>
        /// <param name="sql"><see cref="SQL"/> Main query request body.</param>
        public async Task<QueryResponse> ValidateQuery(SQL sql)
        {
            try
            {
                return await _client.Request("/v1/orgs/self/queries/validations")
                                .PostJsonAsync(new
                                {
                                    sql = sql
                                })
                                .ReceiveJson<QueryResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Add documents to a collection.
        /// </summary>
        /// <param name="workspace">Name of the workspace.</param>
        /// <param name="collection"> Name of the collection.</param>
        /// <param name="data">Array of documents to be added to the document</param>
        public async Task<DocumentResponse> AddDocument(string workspace, string collection, object data)
        {
            try
            {
                return await _client.Request($" / v1/orgs/self/ws/{workspace}/collections/{collection}/docs")
                .PostJsonAsync(new
                {
                    data = data
                })
                .ReceiveJson<DocumentResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }

        }

        /// <summary>
        /// Delete documents from a collection.
        /// </summary>
        /// <param name="workspace">Name of the workspace.</param>
        /// <param name="collection"> Name of the collection.</param>
        /// <param name="data">Array of IDs of documents to be deleted</param>
        public async Task<DocumentResponse> DeleteDocument(string workspace, string collection, List<DeleteDocumentData> data)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/collections/{collection}/docs")
               .SendJsonAsync(HttpMethod.Delete, new
               {
                   data = data
               })
               .ReceiveJson<DocumentResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }

        }

        /// <summary>
        /// Create a new API key for the authenticated user.
        /// </summary>
        /// <param name="key">ApiKey object containing name (required) and role (optional)</param>
        public async Task<CollectionResponse> CreateApiKey(ApiKey key)
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
        public async Task<ApiKeyResponse> DeleteApiKey(string user, string name)
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
        public async Task<ApiKeyResponses> ListApiKeys(string user)
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
        public async Task<ApiKeyResponse> GetApiKey(string user, string name)
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
        public async Task<ApiKeyResponse> UpdateApiKey(string user, ApiKey key)
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

        /// <summary>
        /// Create new alias in a workspace.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="alias">Alias object containing name (required), description (optional) and collections (required)</param>
        public async Task<AliasResponse> CreateAlias(string workspace, Alias alias)
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
        public async Task<AliasResponse> DeleteAlias(string workspace, string name)
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
        public async Task<AliasResponses> ListAliases()
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
        public async Task<AliasResponses> ListAliasesInWorkspace(string workspace)
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
        public async Task<AliasResponse> UpdateAlias(string workspace, Alias alias)
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
        public async Task<AliasResponse> GetAlias(string workspace, string name)
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

        /// <summary>
        /// Create new collection in a workspace.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="collection">CreateCollection object containing name (required) as well as collection information</param>
        public async Task<CollectionResponse> CreateCollection(string workspace, CreateCollection collection)
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
        public async Task<int> DeleteCollection(string workspace, string collection)
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
        public async Task<CollectionResponse> GetCollection(string workspace, string collection)
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
        /// Retrieve all collections in an organization or in a workspace
        /// </summary>
        /// <param name="workspace">Name of the workspace. If null or empty, will retrieve all collections in organization</param>
        public async Task<CollectionResponses> ListCollections(string? workspace)
        {
            try
            {
                if (string.IsNullOrEmpty(workspace))
                {
                    return await _client.Request($"/v1/orgs/self/collections")
                                   .GetJsonAsync<CollectionResponses>();
                }
                else
                {
                    return await _client.Request($"/v1/orgs/self/ws/{workspace}/collections")
                                  .GetJsonAsync<CollectionResponses>();
                }

            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }

        }
        /// <summary>
        /// Create a new integration.
        /// </summary>
        /// <param name="source">Source object</param>
        public async Task<IntegrationResponse> CreateIntegration(Source source)
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
        public async Task<int> DeleteIntegration(string integration)
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
        /// List all integrations in an organization..
        /// </summary>
        public async Task<IntegrationResponses> ListIntegrations()
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
        public async Task<IntegrationResponse> GetIntegration(string integration)
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
        /// <summary>
        /// Create a new user for an organization.
        /// </summary>
        /// <param name="user">User object</param>
        public async Task<UserResponse> CreateUser(User user)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users")
                    .PostJsonAsync(user)
                    .ReceiveJson<UserResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Delete a user from an organization.
        /// </summary>
        /// <param name="user">User email</param>
        public async Task<int> DeleteUser(string user)
        {
            try
            {
                var response = await _client.Request($"/v1/orgs/self/users/{user}")
                 .DeleteAsync();
                return response.StatusCode;
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Retrieve all users for an organization.
        /// </summary>
        public async Task<UserResponses> ListUsers()
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users")
                               .GetJsonAsync<UserResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Retrieve currently authenticated user.
        /// </summary>
        public async Task<UserResponse> GetCurrentUser()
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users/self")
                               .GetJsonAsync<UserResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Retrieve user by email.
        /// </summary>
        /// <param name="user">User email</param>
        public async Task<UserResponse> GetUser(string user)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/users/{user}")
                               .GetJsonAsync<UserResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Create a view
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="view">View data</param>
        public async Task<ViewResponse> CreateView(string workspace, View view)
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
        public async Task<int> DeleteView(string workspace, string view)
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
        public async Task<ViewResponses> ListViews(string? workspace)
        {
            try
            {
                if (string.IsNullOrEmpty(workspace))
                {
                    return await _client.Request($"/v1/orgs/self/views")
                        .GetJsonAsync<ViewResponses>();
                }
                else
                {
                    return await _client.Request($"/v1/orgs/self/ws/{workspace}/views")
                        .GetJsonAsync<ViewResponses>();
                }

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
        public async Task<ViewResponse> GetView(string workspace, string view)
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
        public async Task<ViewResponse> UpdateView(string workspace, View view)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/views/{view.name}")
                    .PostJsonAsync(view)
                    .ReceiveJson<ViewResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
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
        /// <summary>
        /// Create a new workspace
        /// </summary>
        /// <param name="workspace">Workspace data</param>
        public async Task<WorkspaceResponse> CreateWorkspace(Workspace workspace)
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
        public async Task<int> DeleteWorkspace(string workspace)
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
        public async Task<WorkspaceResponses> ListWorkspaces(bool acrossRegion = false)
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
        public async Task<WorkspaceResponses> ListWorkspacesInWorkspace(string workspace)
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
        public async Task<WorkspaceResponse> GetWorkspace(string workspace)
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
        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}