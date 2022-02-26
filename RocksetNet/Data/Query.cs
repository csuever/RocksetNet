using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    /// <summary>
    /// Parameters type for SQL
    /// </summary>
    public enum ParameterType
    {
        String,
        Integer,

    }
    public class SQL
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("generate_warnings")]
        public bool GenerateWarnings { get; set; }

        [JsonProperty("profiling_enabled")]
        public bool ProfilingEnabled { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("default_row_limit")]
        public int DefaultRowLimit { get; set; }

        [JsonProperty("paginate")]
        public bool Paginate { get; set; }

        [JsonProperty("initial_paginate_response_doc_count")]
        public int PaginateCount { get; set; }
    }

    public class Parameters
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public ParameterType Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
