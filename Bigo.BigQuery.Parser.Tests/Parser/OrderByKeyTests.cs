using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class OrderByKeyTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.order_by_key());
    }
}