using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class QueriesApi : RocksetApi
    {
        public QueriesApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }

        #region Query Functions
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
        public async Task<QueryResponse> Validate(SQL sql)
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
        #endregion

    }
}
