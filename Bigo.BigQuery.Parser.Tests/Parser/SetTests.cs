using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class SetTests : BaseParserTest
{
    [Theory]
    [InlineData("SET x = 5")]
    [InlineData("SET (a, b, c) = (1 + 3, 'foo', false)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.set());
    }
}