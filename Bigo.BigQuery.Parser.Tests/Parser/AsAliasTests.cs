using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AsAliasTests : BaseParserTest
{
    [Theory]
    [InlineData("alias")]
    [InlineData("AS alias")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.as_alias());
    }
}