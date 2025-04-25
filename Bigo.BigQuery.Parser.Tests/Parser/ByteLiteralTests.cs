using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ByteLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("B\"abc\"")]
    [InlineData("B'''abc'''")]
    [InlineData("b\"\"\"abc\"\"\"")]
    [InlineData("br'abc+'")]
    [InlineData("RB\"abc+\"")]
    [InlineData("Rb'''abc'''")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.byte_literal());
    }
}