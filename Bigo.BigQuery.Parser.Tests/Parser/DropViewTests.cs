using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropViewTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP VIEW myview")]
    [InlineData("DROP VIEW IF EXISTS mydataset.myview")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_view());
    }
}