
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class NamedWindowExpressionTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.named_window_expression());
    }
}