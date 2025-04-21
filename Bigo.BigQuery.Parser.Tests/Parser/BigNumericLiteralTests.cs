using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class BigNumericLiteralTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.big_numeric_literal());
    }
}