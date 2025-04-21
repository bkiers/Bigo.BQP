using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class MinByTests : BaseParserTest
{
    [Theory]
    [InlineData("MIN_BY(fruit, price)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.min_by());
    }
}