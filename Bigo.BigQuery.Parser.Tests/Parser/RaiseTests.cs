using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class RaiseTests : BaseParserTest
{
    [Theory]
    [InlineData("RAISE")]
    [InlineData("raise using message = 'Oops!'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.raise());
    }
}