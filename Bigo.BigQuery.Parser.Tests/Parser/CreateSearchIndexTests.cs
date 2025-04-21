using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateSearchIndexTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE SEARCH INDEX my_index\nON dataset.my_table(ALL COLUMNS)")]
    [InlineData("CREATE SEARCH INDEX my_index\nON dataset.complex_table(\n  a OPTIONS(index_granularity = 'GLOBAL'),\n  my_struct,\n  b)\nOPTIONS (\n  analyzer = 'NO_OP_ANALYZER',\n  default_index_column_granularity = 'COLUMN')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_search_index());
    }
}