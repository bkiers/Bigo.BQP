using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AvgTests : BaseParserTest
{
    [Theory]
    [InlineData("AVG(x)")]
    [InlineData("AVG(DISTINCT x)")]
    [InlineData("AVG(x) OVER (ORDER BY x ROWS BETWEEN 1 PRECEDING AND CURRENT ROW)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.avg());
    }
}