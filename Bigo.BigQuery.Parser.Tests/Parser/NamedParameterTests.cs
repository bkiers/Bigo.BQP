
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class NamedParameterTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.named_parameter());
    }
}
    