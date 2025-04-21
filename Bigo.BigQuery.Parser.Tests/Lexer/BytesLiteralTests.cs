using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class BytesLiteralTests : BaseLexerTest
{
    [Theory]
    [InlineData("B\"abc\"")]
    [InlineData("B'''abc'''")]
    [InlineData("b\"\"\"abc\"\"\"")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.BYTES_LITERAL);
    }
}