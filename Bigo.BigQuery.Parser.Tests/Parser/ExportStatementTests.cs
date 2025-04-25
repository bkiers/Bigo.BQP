using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ExportStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("EXPORT DATA OPTIONS (\n  uri=\"https://spanner.googleapis.com/projects/my-project/instances/my-instance/databases/my-database\",\n  format=\"CLOUD_SPANNER\",\n  spanner_options=\"\"\"{ \"table\": \"my_table\" }\"\"\"\n)\nAS SELECT * FROM `bigquery_table`")]
    [InlineData("EXPORT DATA WITH CONNECTION project.location.connection_id OPTIONS (\n  uri=\"https://spanner.googleapis.com/projects/my-project/instances/my-instance/databases/my-database\",\n  format=\"CLOUD_SPANNER\",\n  spanner_options=\"\"\"{ \"table\": \"my_table\" }\"\"\"\n)\nAS SELECT * FROM `bigquery_table`")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.export_statement());
    }
}