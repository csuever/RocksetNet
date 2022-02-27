using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class QueryLambdasApi : RocksetApi
    {
        public QueryLambdasApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }

        #region Query Lambda Functions
        /// <summary>
        /// Create a Query Lambda in given workspace.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Query Lambda data</param>
        public async Task<QueryLambdaResponse> CreateUpdate(string workspace, QueryLambda queryLambda)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas")
                               .PostJsonAsync(queryLambda)
                               .ReceiveJson<QueryLambdaResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Delete a Query Lambda.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        public async Task<QueryLambdaResponse> Delete(string workspace, string queryLambda)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}")
                               .DeleteAsync()
                               .ReceiveJson<QueryLambdaResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Create a tag for a specific Query Lambda version, or update that tag if it already exists.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        /// <param name="queryLambdaTag">Query Lambda Tag data</param>
        public async Task<QueryLambdaTagResponse> CreateTag(string workspace, string queryLambda, QueryLambdaTag queryLambdaTag)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/tags")
                               .PostJsonAsync(queryLambdaTag)
                               .ReceiveJson<QueryLambdaTagResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Delete a tag for a specific Query Lambda
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        /// <param name="tag">Name of the Query Lambda Tag</param>
        public async Task<QueryLambdaTagResponse> DeleteTag(string workspace, string queryLambda, string tag)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/tags/{tag}")
                               .DeleteAsync()
                               .ReceiveJson<QueryLambdaTagResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// Delete a Query Lambda version.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        /// <param name="version">Version of the Query Lambda</param>
        public async Task<QueryLambdaTagResponse> DeleteVersion(string workspace, string queryLambda, string version)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/version/{version}")
                               .DeleteAsync()
                               .ReceiveJson<QueryLambdaTagResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Execute the Query Lambda version associated with a given tag.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        /// <param name="tag">Name of the Query Lambda Tag</param>
        public async Task<QueryResponse> ExecuteTag(string workspace, string queryLambda, string tag, ExecuteQueryLambda query)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/tags/{tag}")
                .PostJsonAsync(query)
                .ReceiveJson<QueryResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Execute a particular version of a Query Lambda.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        /// <param name="version">Version of the Query Lambda</param>
        public async Task<QueryResponse> ExecuteVersion(string workspace, string queryLambda, string version, ExecuteQueryLambda query)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/tags/{version}")
                .PostJsonAsync(query)
                .ReceiveJson<QueryResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }
        /// <summary>
        /// List all tags associated with a Query Lambda
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        public async Task<QueryLambdaTagResponses> ListTags(string workspace, string queryLambda)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/tags")
                               .GetJsonAsync<QueryLambdaTagResponses>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// List Query Lambda Versions
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        public async Task<QueryLambdaResponse> ListVersions(string workspace, string queryLambda)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/versions")
                               .GetJsonAsync<QueryLambdaResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// List all Query Lambdas in an organization.
        /// </summary>
        public async Task<ListQueryLambdaResponse> List()
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/lambdas")
                               .GetJsonAsync<ListQueryLambdaResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// List all Query Lambdas under given workspace.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        public async Task<ListQueryLambdaResponse> List(string workspace)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas")
                               .GetJsonAsync<ListQueryLambdaResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Retrieve the Query Lambda version associated with a given tag.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        /// <param name="tag">Name of the Query Lambda Tag</param>
        public async Task<QueryLambdaTagResponse> GetTag(string workspace, string queryLambda, string tag)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/tags/{tag}")
                               .GetJsonAsync<QueryLambdaTagResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        /// <summary>
        /// Retrieve details for a specified version of a Query Lambda.
        /// </summary>
        /// <param name="workspace">Name of the workspace</param>
        /// <param name="queryLambda">Name of the Query Lambda</param>
        /// <param name="version">Version of the Query Lambda</param>
        public async Task<QueryLambdaResponse> GetVersion(string workspace, string queryLambda, string version)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/lambdas/{queryLambda}/versions/{version}")
                               .GetJsonAsync<QueryLambdaResponse>();
            }
            catch (FlurlHttpException ex)
            {
                throw new RocksetException(ex.Message, ex.StatusCode);
            }
        }

        #endregion

    }
}
