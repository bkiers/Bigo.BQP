using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateTableTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE TABLE t")]
    [InlineData("CREATE TABLE mydataset.newtable(x INT64 OPTIONS(description=\"An optional INTEGER field\"), y STRUCT <a ARRAY <STRING> OPTIONS(description=\"A repeated STRING field\"), b BOOL>) PARTITION BY _PARTITIONDATE OPTIONS(expiration_timestamp=TIMESTAMP \"2025-01-01 00:00:00 UTC\", partition_expiration_days=1, description=\"a table that expires in 2025, with each partition living for 24 hours\", labels=[(\"org_unit\", \"development\")])")]
    [InlineData("CREATE TABLE mydataset.top_words OPTIONS(description=\"Top ten words per Shakespeare corpus\") AS SELECT corpus, ARRAY_AGG(STRUCT(word, word_count) ORDER BY word_count DESC LIMIT 10) AS top_words FROM `bigquery-public-data`.samples.shakespeare GROUP BY corpus")]
    [InlineData("CREATE TABLE IF NOT EXISTS mydataset.newtable (x INT64, y STRUCT <a ARRAY <STRING>, b BOOL>)\nOPTIONS(\n  expiration_timestamp=TIMESTAMP \"2025-01-01 00:00:00 UTC\",\n  description=\"a table that expires in 2025\",\n  labels=[(\"org_unit\", \"development\")]\n)")]
    [InlineData("CREATE OR REPLACE TABLE mydataset.newtable (x INT64, y STRUCT <a ARRAY <STRING>, b BOOL>)\nOPTIONS(\n  expiration_timestamp=TIMESTAMP \"2025-01-01 00:00:00 UTC\",\n  description=\"a table that expires in 2025\",\n  labels=[(\"org_unit\", \"development\")]\n)")]
    [InlineData("CREATE TABLE mydataset.newtable (\n  x INT64 NOT NULL,\n  y STRUCT <\n    a ARRAY <STRING>,\n    b BOOL NOT NULL,\n    c FLOAT64\n  > NOT NULL,\n  z STRING\n)")]
    [InlineData("CREATE TABLE mydataset.newtable (\n  a STRING,\n  b STRING,\n  c STRUCT <\n    x FLOAT64\n    y ARRAY <STRING>\n  >\n)\nDEFAULT COLLATE 'und:ci'")]
    [InlineData("CREATE TABLE mydataset.newtable (\n  a STRING,\n  b STRING COLLATE 'und:ci',\n  c STRUCT <\n    x FLOAT64\n    y ARRAY <STRING COLLATE 'und:ci'>\n  >\n)")]
    [InlineData("CREATE TABLE mydataset.newtable (\n  x STRING(10),\n  y STRUCT <\n    a ARRAY <BYTES(5)>,\n    b NUMERIC(15, 2) OPTIONS(rounding_mode = 'ROUND_HALF_EVEN'),\n    c FLOAT64\n  >,\n  z BIGNUMERIC(35)\n)")]
    [InlineData("CREATE TABLE mydataset.newtable (transaction_id INT64, transaction_date DATE)\nPARTITION BY transaction_date\nOPTIONS(\n  partition_expiration_days=3,\n  description=\"a table partitioned by transaction_date\"\n)")]
    [InlineData("CREATE TABLE mydataset.days_with_rain\nPARTITION BY date\nOPTIONS (\n  partition_expiration_days=365,\n  description=\"weather stations with precipitation, partitioned by day\"\n) AS\nSELECT\n  DATE(CAST(year AS INT64), CAST(mo AS INT64), CAST(da AS INT64)) AS date,\n  (SELECT ANY_VALUE(name) FROM `bigquery-public-data.noaa_gsod.stations` AS stations\n   WHERE stations.usaf = stn) AS station_name,  -- Stations can have multiple names\n  prcp\nFROM `bigquery-public-data.noaa_gsod.gsod2017` AS weather\nWHERE prcp != 99.9  -- Filter unknown values\n  AND prcp > 0      -- Filter stations/days with no precipitation")]
    [InlineData("CREATE TABLE mydataset.myclusteredtable\n(\n  input_timestamp TIMESTAMP,\n  customer_id STRING,\n  transaction_amount NUMERIC\n)\nPARTITION BY TIMESTAMP_TRUNC(input_timestamp, HOUR)\nCLUSTER BY customer_id\nOPTIONS (\n  partition_expiration_days=3,\n  description=\"a table clustered by customer_id\"\n)")]
    [InlineData("CREATE TABLE mydataset.myclusteredtable\n(\n  customer_id STRING,\n  transaction_amount NUMERIC\n)\nPARTITION BY DATE(_PARTITIONTIME)\nCLUSTER BY\n  customer_id\nOPTIONS (\n  partition_expiration_days=3,\n  description=\"a table clustered by customer_id\"\n)")]
    [InlineData("CREATE TABLE mydataset.myclusteredtable\n(\n  customer_id STRING,\n  transaction_amount NUMERIC\n)\nCLUSTER BY\n  customer_id\nOPTIONS (\n  description=\"a table clustered by customer_id\"\n)")]
    [InlineData("CREATE TABLE mydataset.myclusteredtable\n(\n  input_timestamp TIMESTAMP,\n  customer_id STRING,\n  transaction_amount NUMERIC\n)\nPARTITION BY DATE(input_timestamp)\nCLUSTER BY\n  customer_id\nOPTIONS (\n  partition_expiration_days=3,\n  description=\"a table clustered by customer_id\"\n)\nAS SELECT * FROM mydataset.myothertable")]
    [InlineData("CREATE TABLE mydataset.myclusteredtable\n(\n  customer_id STRING,\n  transaction_amount NUMERIC\n)\nCLUSTER BY\n  customer_id\nOPTIONS (\n  description=\"a table clustered by customer_id\"\n)\nAS SELECT * FROM mydataset.myothertable")]
    [InlineData("CREATE TEMP TABLE Example\n(\n  x INT64,\n  y STRING\n)")]
    [InlineData("CREATE OR REPLACE TABLE\n  myotherdataset.orders\n  PARTITION BY DATE_TRUNC(l_commitdate, YEAR) AS\nSELECT\n  *\nFROM\n  myawsdataset.orders\nWHERE\n  EXTRACT(YEAR FROM l_commitdate) = 1992")]
    [InlineData("CREATE TABLE\n mydataset.orders(id String, numeric_id INT64)\nPARTITION BY _PARTITIONDATE")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_table());
    }
}