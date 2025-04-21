
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ExpressionsAsAliasTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.expressions_as_alias());
    }
}
    