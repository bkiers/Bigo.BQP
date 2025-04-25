using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CoalesceTests : BaseParserTest
{
    [Theory]
    [InlineData("COALESCE (a)")]
    [InlineData("COALESCE (a, b, c)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.coalesce());
    }
}