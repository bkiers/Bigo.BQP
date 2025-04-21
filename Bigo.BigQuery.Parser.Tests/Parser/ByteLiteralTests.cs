
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ByteLiteralTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.byte_literal());
    }
}