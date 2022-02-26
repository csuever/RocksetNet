using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class Args
    {
    }

    public class Mask
    {
        public Args args { get; set; }
    }

    public class Mapping
    {
        public List<object> input_path { get; set; }
        public Mask mask { get; set; }
    }
    public class Status
    {
        public DateTime first_processed_at { get; set; }
        public int records_processed { get; set; }
        public DateTime last_processed_at { get; set; }
        public string state { get; set; }
        public DateTime last_consumed_time { get; set; }
        public int num_documents_processed { get; set; }
        public List<Partition> partitions { get; set; }
        public DateTime scan_start_time { get; set; }
        public DateTime scan_end_time { get; set; }
        public int scan_records_processed { get; set; }
        public int scan_total_records { get; set; }
        public DateTime stream_last_processed_at { get; set; }
        public List<KafkaPartition> kafka_partitions { get; set; }
        public DateTime stream_last_insert_processed_at { get; set; }
        public DateTime stream_last_update_processed_at { get; set; }
        public DateTime stream_last_delete_processed_at { get; set; }
        public int stream_records_inserted { get; set; }
        public int stream_records_updated { get; set; }
        public int stream_records_deleted { get; set; }
        public string message { get; set; }
        public string last_processed_item { get; set; }
        public int total_processed_items { get; set; }
    }
    public class Stats
    {
        public int? doc_count { get; set; }
        public int? purged_doc_count { get; set; }
        public double? fill_progress { get; set; }
        public long? last_queried_ms { get; set; }
        public long? last_updated_ms { get; set; }
        public int? total_size { get; set; }
        public int? total_index_size { get; set; }
        public int? row_index_size { get; set; }
        public int? column_index_size { get; set; }
        public int? inverted_index_size { get; set; }
        public int? range_index_size { get; set; }
        public int? purged_doc_size { get; set; }
        public int? bytes_inserted { get; set; }
        public int? bytes_overwritten { get; set; }
    }

    public class InputField
    {
        public string field_name { get; set; }
        public string if_missing { get; set; }
        public bool is_drop { get; set; }
        public string param { get; set; }
    }

    public class OutputField
    {
        public string field_name { get; set; }
        public string value { get; set; }
        public string on_error { get; set; }
    }

    public class FieldMapping
    {
        public string name { get; set; }
        public bool is_drop_all_fields { get; set; }
        public List<InputField> input_fields { get; set; }
        public OutputField output_field { get; set; }
    }

    public class FieldMappingQuery
    {
        public string sql { get; set; }
    }

    public class Items
    {
        public string type { get; set; }
    }

    public class Keys
    {
        public string type { get; set; }
        public string example { get; set; }
        public string description { get; set; }
        public Items items { get; set; }
    }

    public class ClusteringKey
    {
        public string field_name { get; set; }
        public string type { get; set; }
        public Keys keys { get; set; }
    }
    public class FieldSchema
    {
        public string field_name { get; set; }
        public string field_options { get; set; }
    }

    public class InvertedIndexGroupEncodingOptions
    {
    }

    public class FieldPartition
    {
        public string field_name { get; set; }
        public string type { get; set; }
        public Keys keys { get; set; }
    }
    public class EventTimeInfo
    {
        public string field { get; set; }
        public string format { get; set; }
        public string time_zone { get; set; }
    }
    public class CreateCollection
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<Source> sources { get; set; }
        public int retention_secs { get; set; }
        public int time_partition_resolution_secs { get; set; }
        public bool insert_only { get; set; }
        public EventTimeInfo event_time_info { get; set; }
        public List<FieldMapping> field_mappings { get; set; }
        public FieldMappingQuery field_mapping_query { get; set; }
        public List<ClusteringKey> clustering_key { get; set; }
        public List<FieldSchema> field_schemas { get; set; }
        public InvertedIndexGroupEncodingOptions inverted_index_group_encoding_options { get; set; }

        public CreateCollection()
        {
            sources = new List<Source>();
            field_mappings = new List<FieldMapping>();
            clustering_key = new List<ClusteringKey>();
            field_schemas = new List<FieldSchema>();
        }
    }

    public class CollectionResponses
    {
        public List<CollectionResponseData> data { get; set; }
    }
    public class CollectionResponse
    {
        public CollectionResponseData data { get; set; }
    }
    public class CollectionResponseData
    {
            public string created_at { get; set; }
            public string created_by { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string workspace { get; set; }
            public string status { get; set; }
            public List<Source> sources { get; set; }
            public Stats stats { get; set; }
            public int retention_secs { get; set; }
            public List<FieldMapping> field_mappings { get; set; }
            public FieldMappingQuery field_mapping_query { get; set; }
            public List<ClusteringKey> clustering_key { get; set; }
            public List<Alias> aliases { get; set; }
            public List<FieldSchema> field_schemas { get; set; }
            public InvertedIndexGroupEncodingOptions inverted_index_group_encoding_options { get; set; }
            public List<FieldPartition> fieldPartitions { get; set; }
        }
    


}
