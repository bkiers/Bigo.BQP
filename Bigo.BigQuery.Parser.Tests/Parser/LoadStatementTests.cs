using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class LoadStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("LOAD DATA INTO mydataset.table1\n  FROM FILES(\n    format='AVRO',\n    uris = ['gs://bucket/path/file.avro']\n  )")]
    [InlineData("LOAD DATA INTO mydataset.table1\n  FROM FILES(\n    format='CSV',\n    uris = ['gs://bucket/path/file1.csv', 'gs://bucket/path/file2.csv']\n  )\n")]
    [InlineData("LOAD DATA INTO mydataset.table1(x INT64, y STRING)\n  FROM FILES(\n    skip_leading_rows=1,\n    format='CSV',\n    uris = ['gs://bucket/path/file.csv']\n  )")]
    [InlineData("LOAD DATA INTO mydataset.table1\n  OPTIONS(\n    description=\"my table\",\n    expiration_timestamp=\"2025-01-01 00:00:00 UTC\"\n  )\n  FROM FILES(\n    format='AVRO',\n    uris = ['gs://bucket/path/file.avro']\n  )")]
    [InlineData("LOAD DATA OVERWRITE mydataset.table1\n  FROM FILES(\n    format='AVRO',\n    uris = ['gs://bucket/path/file.avro']\n  )")]
    [InlineData("LOAD DATA INTO TEMP TABLE mydataset.table1\n  FROM FILES(\n    format='AVRO',\n    uris = ['gs://bucket/path/file.avro']\n  )")]
    [InlineData("LOAD DATA INTO mydataset.table1\n  PARTITION BY transaction_date\n  CLUSTER BY customer_id\n  OPTIONS(\n    partition_expiration_days=3\n  )\n  FROM FILES(\n    format='AVRO',\n    uris = ['gs://bucket/path/file.avro']\n  )")]
    [InlineData("LOAD DATA INTO mydataset.table1\nPARTITIONS(_PARTITIONTIME = TIMESTAMP '2016-01-01')\n  PARTITION BY _PARTITIONTIME\n  FROM FILES(\n    format = 'AVRO',\n    uris = ['gs://bucket/path/file.avro']\n  )")]
    [InlineData("LOAD DATA INTO mydataset.table1\n  FROM FILES(\n    format='AVRO',\n    uris = ['gs://bucket/path/*'],\n    hive_partition_uri_prefix='gs://bucket/path'\n  )\n  WITH PARTITION COLUMNS(\n    field_1 STRING, -- column order must match the external path\n    field_2 INT64\n  )")]
    [InlineData("LOAD DATA INTO mydataset.table1\n  FROM FILES(\n    format='AVRO',\n    uris = ['gs://bucket/path/*'],\n    hive_partition_uri_prefix='gs://bucket/path'\n  )\n  WITH PARTITION COLUMNS")]
    [InlineData("LOAD DATA INTO mydataset.testparquet\n  FROM FILES (\n    uris = ['s3://test-bucket/sample.parquet'],\n    format = 'PARQUET'\n  )\n  WITH CONNECTION `aws-us-east-1.test-connection`")]
    [InlineData("LOAD DATA INTO mydataset.test_csv (Number INT64, Name STRING, Time DATE)\n  PARTITION BY Time\n  FROM FILES (\n    format = 'CSV', uris = ['azure://test.blob.core.windows.net/container/sampled*'],\n    skip_leading_rows=1\n  )\n  WITH CONNECTION `azure-eastus2.test-connection`")]
    [InlineData("LOAD DATA OVERWRITE mydataset.testparquet\n  FROM FILES (\n    uris = ['s3://test-bucket/sample.parquet'],\n    format = 'PARQUET'\n  )\n  WITH CONNECTION `aws-us-east-1.test-connection`")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.load_statement());
    }
}