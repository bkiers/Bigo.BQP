using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class SumTests : BaseParserTest
{
    [Theory]
    [InlineData("SUM(x)")]
    [InlineData("SUM(DISTINCT x)")]
    [InlineData("SUM(x) OVER (PARTITION BY MOD(x, 3))")]
    [InlineData("SUM(DISTINCT x) OVER (PARTITION BY MOD(x, 3))")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.sum());
    }
}