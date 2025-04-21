using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateExternalTableTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE OR REPLACE EXTERNAL TABLE mydataset.newtable (x INT64, y STRING, z BOOL)\n  WITH CONNECTION myconnection\n  OPTIONS(\n    format =\"PARQUET\",\n    max_staleness = STALENESS_INTERVAL,\n    metadata_cache_mode = 'AUTOMATIC')")]
    [InlineData("CREATE EXTERNAL TABLE dataset.CsvTable OPTIONS (\n  format = 'CSV',\n  uris = ['gs://bucket/path1.csv', 'gs://bucket/path2.csv']\n)")]
    [InlineData("CREATE OR REPLACE EXTERNAL TABLE dataset.CsvTable\n(\n  x INT64,\n  y STRING\n)\nOPTIONS (\n  format = 'CSV',\n  uris = ['gs://bucket/path1.csv'],\n  field_delimiter = '|',\n  max_bad_records = 5\n)")]
    [InlineData("CREATE EXTERNAL TABLE dataset.AutoHivePartitionedTable\nWITH PARTITION COLUMNS\nOPTIONS (\n  uris = ['gs://bucket/path/*'],\n  format = 'PARQUET',\n  hive_partition_uri_prefix = 'gs://bucket/path',\n  require_hive_partition_filter = false)")]
    [InlineData("CREATE EXTERNAL TABLE dataset.CustomHivePartitionedTable\nWITH PARTITION COLUMNS (\n  field_1 STRING, -- column order must match the external path\n  field_2 INT64)\nOPTIONS (\n  uris = ['gs://bucket/path/*'],\n  format = 'PARQUET',\n  hive_partition_uri_prefix = 'gs://bucket/path',\n  require_hive_partition_filter = false)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_external_table());
    }
}