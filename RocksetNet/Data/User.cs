using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class User
    {
        public string email { get; set; }
        public List<string> roles { get; set; }
    }

    public class UserResponse
    {
        public UserResponseData data { get; set; }
    }

    public class UserResponses
    {
        public List<UserResponseData> data { get; set; }
    }

    public class UserResponseData
    {
        public string created_at { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }   
        public List<string> roles { get; set; }
        public string state { get; set; }
    }
}
