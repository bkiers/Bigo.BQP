using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class MaxByTests : BaseParserTest
{
    [Theory]
    [InlineData("MAX_BY(fruit, price)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.max_by());
    }
}