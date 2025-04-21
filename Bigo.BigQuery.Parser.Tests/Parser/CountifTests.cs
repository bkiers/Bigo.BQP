using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CountifTests : BaseParserTest
{
    [Theory]
    [InlineData("COUNTIF(x<0)")]
    [InlineData("COUNTIF(x<0) OVER (ORDER BY ABS(x) ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.countif());
    }
}