using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class DocumentsApi : RocksetApi
    {
        public DocumentsApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }
        #region Document Functions
        /// <summary>
        /// Add documents to a collection.
        /// </summary>
        /// <param name="workspace">Name of the workspace.</param>
        /// <param name="collection"> Name of the collection.</param>
        /// <param name="data">Array of documents to be added to the document</param>
        public async Task<DocumentResponse> Create(string workspace, string collection, object data)
        {
            try
            {
                return await _client.Request($"/v1/orgs/self/ws/{workspace}/collections/{collection}/docs")
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
        public async Task<DocumentResponse> Delete(string workspace, string collection, List<DeleteDocumentData> data)
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
        #endregion
    }
}
