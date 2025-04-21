using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class MinTests : BaseParserTest
{
    [Theory]
    [InlineData("MIN(x)")]
    [InlineData("MIN(x) OVER (PARTITION BY MOD(x, 2))")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.min());
    }
}