using RocksetNet.Data;

namespace RocksetNet
{
    public interface IRocksetClient
    {
        Task<DocumentResponse> AddDocument(string workspace, string collection, object data);
        Task<AliasResponse> CreateAlias(string workspace, Alias alias);
        Task<CollectionResponse> CreateApiKey(ApiKey key);
        Task<CollectionResponse> CreateCollection(string workspace, CreateCollection collection);
        Task<IntegrationResponse> CreateIntegration(Source source);
        Task<UserResponse> CreateUser(User user);
        Task<ViewResponse> CreateView(string workspace, View view);
        Task<WorkspaceResponse> CreateWorkspace(Workspace workspace);
        Task<AliasResponse> DeleteAlias(string workspace, string name);
        Task<ApiKeyResponse> DeleteApiKey(string user, string name);
        Task<int> DeleteCollection(string workspace, string collection);
        Task<DocumentResponse> DeleteDocument(string workspace, string collection, List<DeleteDocumentData> data);
        Task<int> DeleteIntegration(string integration);
        Task<int> DeleteUser(string email);
        Task<int> DeleteView(string workspace, string view);
        Task<int> DeleteWorkspace(string workspace);
        Task<AliasResponse> GetAlias(string workspace, string alias);
        Task<ApiKeyResponse> GetApiKey(string user, string name);
        Task<CollectionResponse> GetCollection(string workspace, string collection);
        Task<UserResponse> GetCurrentUser();
        Task<IntegrationResponse> GetIntegration(string integration);
        Task<UserResponse> GetUser(string email);
        Task<ViewResponse> GetView(string workspace, string view);
        Task<VirtualInstanceResponse> GetVirtualInstance(string virtualInstanceId);
        Task<WorkspaceResponse> GetWorkspace(string workspace);
        Task<AliasResponses> ListAliases();
        Task<AliasResponses> ListAliasesInWorkspace(string workspace);
        Task<ApiKeyResponses> ListApiKeys(string user);
        Task<CollectionResponses> ListCollections(string? workspace);
        Task<IntegrationResponses> ListIntegrations();
        Task<UserResponses> ListUsers();
        Task<ViewResponses> ListViews(string? workspace);
        Task<VirtualInstanceResponses> ListVirtualInstances();
        Task<WorkspaceResponses> ListWorkspaces(bool acrossRegion = false);
        Task<WorkspaceResponses> ListWorkspacesInWorkspace(string workspace);
        Task<QueryResponse> Query(SQL sql);
        Task<AliasResponse> UpdateAlias(string workspace, Alias alias);
        Task<ApiKeyResponse> UpdateApiKey(string user, ApiKey key);
        Task<ViewResponse> UpdateView(string workspace, View view);
        Task<VirtualInstanceResponse> UpdateVirtualInstance(string virtualInstanceId, VirtualInstance instance);
        Task<QueryResponse> ValidateQuery(SQL sql);
    }
}