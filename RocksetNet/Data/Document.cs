using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class DocumentResponse
    {
        [JsonProperty("data")]
        public List<ResponseInformation> Data { get; set; }
    }

    public class ResponseInformation
    {
        [JsonProperty("_collection")]
        public string Collection { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("patch_id")]
        public string PatchId { get; set; }
    }
    public class Document
    {
        [JsonProperty("Workspace")]
        public string Workspace { get; set; }

        [JsonProperty("collection")]
        public string Collection { get; set; }
    }

    public class DeleteDocumentData
    {

        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
