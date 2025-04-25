using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropSearchIndexTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP SEARCH INDEX my_index ON tbl")]
    [InlineData("DROP SEARCH INDEX if exists my_index ON dataset.my_table")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_search_index());
    }
}