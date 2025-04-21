using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class BitOrTests : BaseParserTest
{
    [Theory]
    [InlineData("BIT_OR(x)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.bit_or());
    }
}