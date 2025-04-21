using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class BitAndTests : BaseParserTest
{
    [Theory]
    [InlineData("BIT_AND(x)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.bit_and());
    }
}