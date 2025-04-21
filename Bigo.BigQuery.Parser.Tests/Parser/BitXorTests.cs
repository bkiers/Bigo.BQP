using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class BitXorTests : BaseParserTest
{
    [Theory]
    [InlineData("BIT_XOR(x)")]
    [InlineData("BIT_XOR(distinct x)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.bit_xor());
    }
}