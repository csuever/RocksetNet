using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocksetNet.Data
{
    public class Source
    {
        public string integration_name { get; set; }
        public S3 s3 { get; set; }
        public Kinesis kinesis { get; set; }
        public Gcs gcs { get; set; }
        public AzureBlobStorage azure_blob_storage { get; set; }
        public AzureServiceBus azure_service_bus { get; set; }
        public AzureEventHub azure_event_hub { get; set; }
        public Redshift redshift { get; set; }
        public Dynamodb dynamodb { get; set; }
        public FileUpload file_upload { get; set; }
        public Kafka kafka { get; set; }
        public Mongodb mongodb { get; set; }
        public Status status { get; set; }
        public FormatParams format_params { get; set; }
    }

    public class AzureServiceBus
    {
        public string topic { get; set; }
        public string subscription { get; set; }
        public Status status { get; set; }
    }

    public class Partition
    {
        public int partition_number { get; set; }
        public int partition_offset { get; set; }
        public int offset_lag { get; set; }
    }

    public class AzureEventHub
    {
        public string hub_id { get; set; }
        public string offset_reset_policy { get; set; }
        public Status status { get; set; }
    }

    public class Redshift
    {
        public string database { get; set; }
        public string schema { get; set; }
        public string table_name { get; set; }
        public string incremental_field { get; set; }
    }

    public class CurrentStatus
    {
        public double initial_dump_completion_percentage { get; set; }
        public string state { get; set; }
        public DateTime stream_last_processed_at { get; set; }
    }

    public class Dynamodb
    {
        public string aws_region { get; set; }
        public string table_name { get; set; }
        public CurrentStatus current_status { get; set; }
        public int rcu { get; set; }
        public Status status { get; set; }
    }

    public class FileUpload
    {
        public string file_name { get; set; }
        public int file_size { get; set; }
        public DateTime file_upload_time { get; set; }
    }

    public class KafkaPartition
    {
        public int partition_number { get; set; }
        public int partition_offset { get; set; }
        public int offset_lag { get; set; }
    }

    public class Kafka
    {
        public string kafka_topic_name { get; set; }
        public Status status { get; set; }
    }

    public class Mongodb
    {
        public string database_name { get; set; }
        public string collection_name { get; set; }
        public Status status { get; set; }
    }

    public class Csv
    {
        public bool firstLineAsColumnNames { get; set; }
        public string separator { get; set; }
        public string encoding { get; set; }
        public List<string> columnNames { get; set; }
        public List<string> columnTypes { get; set; }
        public string quoteChar { get; set; }
        public string escapeChar { get; set; }
    }

    public class Xml
    {
        public string root_tag { get; set; }
        public string encoding { get; set; }
        public string doc_tag { get; set; }
        public string value_tag { get; set; }
        public string attribute_prefix { get; set; }
    }

    public class FormatParams
    {
        public bool json { get; set; }
        public Csv csv { get; set; }
        public Xml xml { get; set; }
    }

    public class S3
    {
        public string access_key { get; set; }
        public string secret_access { get; set; }
        public string prefix { get; set; }
        public string pattern { get; set; }
        public string region { get; set; }
        public string bucket { get; set; }
        public List<string> prefixes { get; set; }
        public string format { get; set; }
        public List<Mapping> mappings { get; set; }
    }

    public class Kinesis
    {
        public string aws_region { get; set; }
        public string stream_name { get; set; }
        public List<object> dms_primary_key { get; set; }
        public string offset_reset_policy { get; set; }
    }

    public class Gcs
    {
        public string bucket { get; set; }
        public string prefix { get; set; }
        public string pattern { get; set; }
    }

    public class AzureBlobStorage
    {
        public string container { get; set; }
        public string prefix { get; set; }
        public string pattern { get; set; }
    }
}
