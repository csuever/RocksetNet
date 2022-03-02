using Flurl;
using Flurl.Http;
using RocksetNet.Api;
using RocksetNet.Data;
using RocksetNet.Exceptions;

namespace RocksetNet.Configuration
{
    public enum Region
    {
        USWest,
        USEast,
        EUCentral
    }
    public class RocksetApiConfiguration
    {
        public string ApiKey { get; private set; }
        public string BaseUrl { get; private set; }
        /// <summary>
        /// Initializes a <see cref="RocksetApiConfiguration"/> to set configuration information.
        /// </summary>
        /// <param name="apiKey">API key used to authenticate requests</param>
        /// <param name="region">Region of your organization</param>
        public RocksetApiConfiguration(string apiKey, Region region = Region.USEast)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new RocksetException("Api key cannot be empty");
            }
            ApiKey = apiKey;

            switch (region)
            {
                case Region.USWest:
                    BaseUrl = "https://api.rs2.usw2.rockset.com";
                    break;
                case Region.USEast:
                    BaseUrl = "https://api.use1a1.rockset.com";
                    break;
                case Region.EUCentral:
                    BaseUrl = "https://api.euc1a1.rockset.com";
                    break;
            }

            
        }
    }
}