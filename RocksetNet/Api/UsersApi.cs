using Flurl.Http;
using RocksetNet.Data;
using RocksetNet.Exceptions;
using RocksetNet.Configuration;

namespace RocksetNet.Api
{
    public class UsersApi : RocksetApi
    {
        public UsersApi(RocksetApiConfiguration configuration) : base(configuration)
        {
        }
        #region User Functions
        /// <summary>
        /// Create a new user for an organization.
        /// </summary>
        /// <param name="user">User object</param>
        public async Task<UserResponse> Create(User user)
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
        public async Task<int> Delete(string user)
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
        public async Task<UserResponses> List()
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
        public async Task<UserResponse> GetCurrent()
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
        public async Task<UserResponse> Get(string user)
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
        #endregion
    }
}
