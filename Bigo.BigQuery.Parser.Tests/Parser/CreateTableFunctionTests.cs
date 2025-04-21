using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateTableFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE OR REPLACE TABLE FUNCTION mydataset.names_by_year(y INT64)\nAS\n  SELECT year, name, SUM(number) AS total\n  FROM `bigquery-public-data.usa_names.usa_1910_current`\n  WHERE year = y\n  GROUP BY year, name")]
    [InlineData("CREATE OR REPLACE TABLE FUNCTION mydataset.names_by_year(y INT64)\nRETURNS TABLE<name STRING, year INT64, total INT64>\nAS\n  SELECT year, name, SUM(number) AS total\n  FROM `bigquery-public-data.usa_names.usa_1910_current`\n  WHERE year = y\n  GROUP BY year, name")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_table_function());
    }
}