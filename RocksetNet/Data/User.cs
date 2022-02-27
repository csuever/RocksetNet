using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RocksetNet.Data
{
    public class User
    {

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
    }

    public class UserResponses
    {
        public List<UserResponse> users { get; set; }
    }

    public class UserResponse
    {

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
