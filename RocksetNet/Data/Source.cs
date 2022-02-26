using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class Source
    {
        [JsonProperty("integration_name")]
        public string Name { get; set; }

        [JsonProperty("s3")]
        public S3 s3 { get; set; }

        [JsonProperty("kinesis")]
        public Kinesis Kinesis { get; set; }

        [JsonProperty("gcs")]
        public Gcs Gcs { get; set; }

        [JsonProperty("azure_blob_storage")]
        public AzureBlobStorage AzureBlobStorage { get; set; }

        [JsonProperty("azure_service_bus")]
        public AzureServiceBus AzureServiceBus { get; set; }

        [JsonProperty("azure_event_hub")]
        public AzureEventHub AzureEventHub { get; set; }

        [JsonProperty("redshift")]
        public Redshift Redshift { get; set; }

        [JsonProperty("dynamodb")]
        public Dynamodb DynamoDB { get; set; }

        [JsonProperty("file_upload")]
        public FileUpload FileUpload { get; set; }

        [JsonProperty("kafka")]
        public Kafka Kafka { get; set; }

        [JsonProperty("mongodb")]
        public Mongodb MongoDB { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("format_params")]
        public FormatParams FormatParams { get; set; }
    }

    public class AzureServiceBus
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("subscription")]
        public string Subscription { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Partition
    {
        [JsonProperty("partition_number")]
        public int PartitionNumber { get; set; }

        [JsonProperty("partition_offset")]
        public int PartitionOffset { get; set; }

        [JsonProperty("offset_lag")]
        public int OffsetLag { get; set; }
    }

    public class AzureEventHub
    {
        [JsonProperty("hub_id")]
        public string Id { get; set; }

        [JsonProperty("offset_reset_policy")]
        public string OffsetResetPolicy { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Redshift
    {
        [JsonProperty("database")]
        public string Database { get; set; }

        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("table_name")]
        public string TableName { get; set; }

        [JsonProperty("incremental_field")]
        public string IncrementalField { get; set; }
    }

    public class CurrentStatus
    {

        [JsonProperty("initial_dump_completion_percentage")]
        public double InitialDumpCompletion { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("stream_last_processed_at")]
        public DateTime StreamLastProcessed { get; set; }
    }

    public class Dynamodb
    {

        [JsonProperty("aws_region")]
        public string Region { get; set; }

        [JsonProperty("table_name")]
        public string table_name { get; set; }

        [JsonProperty("current_status")]
        public CurrentStatus CurrentStatus { get; set; }

        [JsonProperty("rcu")]
        public int Rcu { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class FileUpload
    {

        [JsonProperty("file_name")]
        public string Name { get; set; }

        [JsonProperty("file_size")]
        public int Size { get; set; }

        [JsonProperty("file_upload_time")]
        public DateTime Uploadtime { get; set; }
    }

    public class KafkaPartition
    {

        [JsonProperty("partition_number")]
        public int Number { get; set; }

        [JsonProperty("partition_offset")]
        public int Offset { get; set; }

        [JsonProperty("offset_lag")]
        public int Lag { get; set; }
    }

    public class Kafka
    {

        [JsonProperty("kafka_topic_name")]
        public string TopicName { get; set; }

        [JsonProperty("kafka_topic_name")]
        public Status Status { get; set; }
    }

    public class Mongodb
    {
        [JsonProperty("database_name")]
        public string Database { get; set; }

        [JsonProperty("collection_name")]
        public string Collection { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Csv
    {

        [JsonProperty("firstLineAsColumnNames")]
        public bool FirstLineAsColumn { get; set; }

        [JsonProperty("separator")]
        public string Separator { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("columnNames")]
        public List<string> ColumnNames { get; set; }

        [JsonProperty("columnTypes")]
        public List<string> ColumnTypes { get; set; }

        [JsonProperty("quoteChar")]
        public string QuoteChar { get; set; }

        [JsonProperty("escapeChar")]
        public string EscapeChar { get; set; }
    }

    public class Xml
    {

        [JsonProperty("root_tag")]
        public string RootTag { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("doc_tag")]
        public string DocTag { get; set; }

        [JsonProperty("value_tag")]
        public string ValueTag { get; set; }

        [JsonProperty("attribute_prefix")]
        public string AttributePrefix { get; set; }
    }

    public class FormatParams
    {

        [JsonProperty("json")]
        public bool IsJson { get; set; }

        [JsonProperty("csv")]
        public Csv Csv { get; set; }

        [JsonProperty("xml")]
        public Xml Xml { get; set; }
    }

    public class S3
    {

        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        [JsonProperty("secret_access")]
        public string SecretKey { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        [JsonProperty("prefixes")]
        public List<string> Prefixes { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("mappings")]
        public List<Mapping> Mappings { get; set; }
    }

    public class Kinesis
    {

        [JsonProperty("aws_region")]
        public string Region { get; set; }

        [JsonProperty("stream_name")]
        public string StreamName { get; set; }

        [JsonProperty("dms_primary_key")]
        public List<object> DmsPrimayKey { get; set; }

        [JsonProperty("offset_reset_policy")]
        public string OffsetResetPolicy { get; set; }
    }

    public class Gcs
    {

        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }
    }

    public class AzureBlobStorage
    {

        [JsonProperty("bucket")]
        public string Bucket { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }
    }
}
