using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class IntegerLiteralTests : BaseLexerTest
{
    [Theory]
    [InlineData("123")]
    [InlineData("0xABC")]
    [InlineData("-123")]
    [InlineData("+0X1111")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.INTEGER_LITERAL);
    }
}