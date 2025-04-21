using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class MaxTests : BaseParserTest
{
    [Theory]
    [InlineData("MAX(x)")]
    [InlineData("MAX(x) OVER (PARTITION BY MOD(x, 2))")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.max());
    }
}