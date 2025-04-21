using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class RawBytesLiteralTests : BaseLexerTest
{
    [Theory]
    [InlineData("br'abc+'")]
    [InlineData("RB\"abc+\"")]
    [InlineData("Rb'''abc'''")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.RAW_BYTES_LITERAL);
    }
}