using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class QueryLambda
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sql")]
        public QueryLambdaSql Sql { get; set; }

        [JsonProperty("create")]
        public bool Create { get; set; }
    }
    public class QueryLambdaTag
    {
        [JsonProperty("tag_name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
    public class QueryLambdaResponse
    {
        public QueryLambdaResponseData data { get; set; }
    }
    public class QueryLambdaTagResponses { 
    public List<QueryLambdaTag> data { get; set; }
    }
    public class QueryLambdaResponses
    {
        public List<QueryLambdaResponseData> data { get; set; }
    }
    public class QueryLambdaResponseData
    {
        [JsonProperty("workspace")]
        public string Workspace { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sql")]
        public QueryLambdaSql Sql { get; set; }

        [JsonProperty("collections")]
        public List<object> Collections { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }
    }
    public class QueryLambdaTagResponse
    {
        public QueryLambdaTag data { get; set; }
    }

    public class ListQueryLambdaResponse
    {
        public List<ListQueryLambdaResponseData> data { get; set; }
    }
    public class ListQueryLambdaResponseData
    {
        [JsonProperty("workspace")]
        public string Workspace { get; set; }

        [JsonProperty("last_updated_by")]
        public string LastUpdatedBy { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version_count")]
        public int VersionCount { get; set; }

        [JsonProperty("collections")]
        public List<object> Collections { get; set; }

        [JsonProperty("latest_version")]
        public LatestVersion LatestVersion { get; set; }
    }
    public class QueryLambdaSql
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("default_parameters")]
        public List<DefaultParameter> DefaultParameters { get; set; }

        public QueryLambdaSql()
        {
            this.DefaultParameters = new List<DefaultParameter>();
        }
    }
    public class DefaultParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class ExecuteQueryLambda
    {
        [JsonProperty("parameters")]
        public List<DefaultParameter> Parameters { get; set; }

        [JsonProperty("default_row_limit")]
        public int DefaultRowLimit { get; set; }

        [JsonProperty("generate_warnings")]
        public bool GenerateWarnings { get; set; }

        [JsonProperty("paginate")]
        public bool Paginate { get; set; }

        [JsonProperty("initial_paginate_response_doc_count")]
        public int PaginateCount { get; set; }
    }
    public class LatestVersion
    {
        [JsonProperty("workspace")]
        public string Workspace { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sql")]
        public QueryLambdaSql Sql { get; set; }

        [JsonProperty("collections")]
        public List<object> Collections { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }
    }


}
