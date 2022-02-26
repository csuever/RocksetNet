using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RocksetNet.Data
{
    public class Args
    {
    }

    public class Mask
    {
        [JsonProperty("args")]
        public Args Args { get; set; }
    }

    public class Mapping
    {
        [JsonProperty("input_path")]
        public List<object> InputPath { get; set; }

        [JsonProperty("mask")]
        public Mask Mask { get; set; }
    }
    public class Status
    {

        [JsonProperty("first_processed_at")]
        public DateTime FirstProcessed { get; set; }

        [JsonProperty("records_processed")]
        public int RecordsProcessed { get; set; }

        [JsonProperty("last_processed_at")]
        public DateTime LastProcessed { get; set; }
        [JsonProperty("staet")]
        public string State { get; set; }

        [JsonProperty("last_consumed_time")]
        public DateTime LastConsumed { get; set; }

        [JsonProperty("num_documents_processed")]
        public int DocumentsProcessed { get; set; }

        [JsonProperty("partitions")]
        public List<Partition> Partitions { get; set; }

        [JsonProperty("scan_start_time")]
        public DateTime ScanStartTime { get; set; }

        [JsonProperty("scan_end_time")]
        public DateTime ScanEndTime { get; set; }

        [JsonProperty("scan_records_processed")]
        public int ScanRecordsProcessed { get; set; }

        [JsonProperty("scan_total_records")]
        public int ScanTotalRecords { get; set; }

        [JsonProperty("stream_last_processed_at")]
        public DateTime StreamLastProcessed { get; set; }

        [JsonProperty("kafka_partitions")]
        public List<KafkaPartition> KafkaPartitions { get; set; }

        [JsonProperty("stream_last_insert_processed_at")]
        public DateTime StreamLastInsert { get; set; }

        [JsonProperty("stream_last_update_processed_at")]
        public DateTime StreamLastUpdate { get; set; }

        [JsonProperty("stream_last_delete_processed_at")]
        public DateTime StreamLastDelete { get; set; }

        [JsonProperty("stream_records_inserted")]
        public int StreamRecordsInserted { get; set; }

        [JsonProperty("stream_records_updated")]
        public int StreamRecordsUpdated { get; set; }

        [JsonProperty("stream_records_deleted")]
        public int StreamRecordsDeleted { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("last_processed_item")]
        public string LastProcessedItem { get; set; }

        [JsonProperty("total_processed_items")]
        public int TotalItemsProcessed { get; set; }
    }
    public class Stats
    {
        [JsonProperty("doc_count")]
        public int? DocumentCount { get; set; }

        [JsonProperty("purged_doc_count")]
        public int? PurgedDocumentCount { get; set; }

        [JsonProperty("fill_progress")]
        public double? FillProgress { get; set; }

        [JsonProperty("last_queried_ms")]
        public long? LastQueriedMs { get; set; }

        [JsonProperty("last_updated_ms")]
        public long? LastUpdatedMs { get; set; }

        [JsonProperty("total_size")]
        public int? TotalSize { get; set; }

        [JsonProperty("total_index_size")]
        public int? TotalIndexSize { get; set; }

        [JsonProperty("row_index_size")]
        public int? RowIndexSize { get; set; }

        [JsonProperty("column_index_size")]
        public int? ColumnIndexSize { get; set; }

        [JsonProperty("inverted_index_size")]
        public int? InvertedIndexSize { get; set; }

        [JsonProperty("range_index_size")]
        public int? RangeIndexSize { get; set; }

        [JsonProperty("purged_doc_size")]
        public int? PurgedDocumentSize { get; set; }

        [JsonProperty("bytes_inserted")]
        public int? BytesInserted { get; set; }

        [JsonProperty("bytes_overwritten")]
        public int? BytesOverwritten { get; set; }
    }

    public class InputField
    {
        [JsonProperty("field_name")]
        public string FieldName { get; set; }

        [JsonProperty("if_missing")]
        public string IfMissing { get; set; }

        [JsonProperty("is_drop")]
        public bool IsDrop { get; set; }

        [JsonProperty("param")]
        public string Parameter { get; set; }
    }

    public class OutputField
    {
        [JsonProperty("field_name")]
        public string FieldName { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("on_error")]
        public string OnError { get; set; }
    }

    public class FieldMapping
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_drop_all_fields")]
        public bool DropAllFields { get; set; }

        [JsonProperty("input_fields")]
        public List<InputField> InputFields { get; set; }

        [JsonProperty("output_field")]
        public OutputField OutputField { get; set; }
    }

    public class FieldMappingQuery
    {
        [JsonProperty("sql")]
        public string Sql { get; set; }
    }

    public class Items
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Keys
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("items")]
        public Items Items { get; set; }
    }

    public class ClusteringKey
    {
        [JsonProperty("field_name")]
        public string FieldName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("keys")]
        public Keys Keys { get; set; }
    }
    public class FieldSchema
    {
        [JsonProperty("field_name")]
        public string FieldName { get; set; }

        [JsonProperty("field_options")]
        public string FieldOptions { get; set; }
    }

    public class InvertedIndexGroupEncodingOptions
    {
    }

    public class FieldPartition
    {

        [JsonProperty("field_name")]
        public string FieldName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("keys")]
        public Keys Keys { get; set; }
    }
    public class EventTimeInfo
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
    }
    public class CreateCollection
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sources")]
        public List<Source> Sources { get; set; }

        [JsonProperty("retention_secs")]
        public int Retention { get; set; }

        [JsonProperty("time_partition_resolution_secs")]
        public int TimePartitionResolution { get; set; }

        [JsonProperty("insert_only")]
        public bool InsertOnly { get; set; }

        [JsonProperty("event_time_info")]
        public EventTimeInfo EventTime { get; set; }

        [JsonProperty("field_mappings")]
        public List<FieldMapping> FieldMappings { get; set; }

        [JsonProperty("field_mapping_query")]
        public FieldMappingQuery FieldMappingQuery { get; set; }

        [JsonProperty("clustering_key")]
        public List<ClusteringKey> ClusteringKeys { get; set; }

        [JsonProperty("field_schemas")]
        public List<FieldSchema> FieldSchemas { get; set; }

        [JsonProperty("inverted_index_group_encoding_options")]
        public InvertedIndexGroupEncodingOptions InvertedIndexGroupEncodingOptions { get; set; }

        public CreateCollection()
        {
            Sources = new List<Source>();
            FieldMappings = new List<FieldMapping>();
            ClusteringKeys = new List<ClusteringKey>();
            FieldSchemas = new List<FieldSchema>();
        }
    }

    public class CollectionResponses
    {
        [JsonProperty("data")]
        public List<CollectionResponseData> Data { get; set; }
    }
    public class CollectionResponse
    {
        [JsonProperty("data")]
        public CollectionResponseData Data { get; set; }
    }
    public class CollectionResponseData
    {

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("workspace")]
        public string Workspace { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("sources")]
        public List<Source> Sources { get; set; }

        [JsonProperty("stats")]
        public Stats Statistics { get; set; }

        [JsonProperty("retention_secs")]
        public int Retention { get; set; }

        [JsonProperty("field_mappings")]
        public List<FieldMapping> FieldMappings { get; set; }

        [JsonProperty("field_mapping_query")]
        public FieldMappingQuery FieldMappingQuery { get; set; }

        [JsonProperty("clustering_key")]
        public List<ClusteringKey> ClusteringKeys { get; set; }

        [JsonProperty("field_schemas")]
        public List<FieldSchema> FieldSchemas { get; set; }

        [JsonProperty("inverted_index_group_encoding_options")]
        public InvertedIndexGroupEncodingOptions InvertedIndexGroupEncodingOptions { get; set; }

        [JsonProperty("aliases")]
        public List<Alias> Aliases { get; set; }

        [JsonProperty("fieldPartitions")]
        public List<FieldPartition> FieldPartitions { get; set; }
    }



}
