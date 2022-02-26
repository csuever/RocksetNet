using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet
{
    public class Stats
    {
        [JsonProperty("elasped_time_ms")]
        public int ElapsedTime{ get; set; }

        [JsonProperty("throttled_time_micros")]
        public int ThrottledTime { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("current_page_doc_count")]
        public int CurrentPage { get; set; }

        [JsonProperty("next_cursor_offset")]
        public int NextCursorOffset { get; set; }

        [JsonProperty("start_cursor")]
        public string StartCursor { get; set; }

        [JsonProperty("next_cursor")]
        public int NextCursor { get; set; }
    }
    public class QueryResponse
    {
        [JsonProperty("query_id")]
        public string QueryId { get; set; }

        [JsonProperty("collections")]
        public List<object> Collections { get; set; }

        [JsonProperty("results")]
        public List<dynamic> Results { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("warnings")]
        public List<object> warnings { get; set; }

        [JsonProperty("query_lambda_path")]
        public string LambdaPath { get; set; }

        [JsonProperty("query_errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("column_fields")]
        public List<object> ColumnFields { get; set; }

        [JsonProperty("results_total_doc_count")]
        public int TotalDocCount { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("last_offset")]
        public string LastOffset { get; set; }
    }
}
