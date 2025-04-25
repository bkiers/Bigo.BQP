using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateTableCopyTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE OR REPLACE TABLE my_dataset.new_table\nCOPY my_dataset.existing_table\nOPTIONS(\n  description=\"New table created from existing_table\",\n  partition_expiration_ms=3600000\n)")]
    [InlineData("CREATE TABLE IF NOT EXISTS my_dataset.new_table\nCOPY my_dataset.existing_table\nOPTIONS(\n  partition_expiration_ms=86400000\n)")]
    [InlineData("CREATE TABLE my_dataset.new_table\nCOPY my_dataset.existing_table")]
    [InlineData("CREATE OR REPLACE TABLE my_dataset.sales_summary\nCOPY my_dataset.raw_sales_data\nOPTIONS(\n  description=\"Aggregated sales data\",\n  partition_expiration_ms=2592000000, \n  clustering_fields=[\"region\", \"product\"]\n)")]
    [InlineData("CREATE TABLE my_dataset.new_table\nCOPY my_dataset.old_table")]
    [InlineData("CREATE TABLE IF NOT EXISTS my_dataset.employee_data\nCOPY my_dataset.raw_employee_data\nOPTIONS(\n  description=\"Table containing employee records\"\n)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_table_copy());
    }
}