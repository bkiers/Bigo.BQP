using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AnyValueTests : BaseParserTest
{
    [Theory]
    [InlineData("ANY_VALUE(fruit)")]
    [InlineData("ANY_VALUE(fruit) OVER (ORDER BY LENGTH(fruit) ROWS BETWEEN 1 PRECEDING AND CURRENT ROW)")]
    [InlineData("ANY_VALUE(fruit HAVING MAX sold)")]
    [InlineData("ANY_VALUE(fruit HAVING MIN sold)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.any_value());
    }
}