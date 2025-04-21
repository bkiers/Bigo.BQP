using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class FloatingPointLiteralTests : BaseLexerTest
{
    [Theory]
    [InlineData("123.456e-67")]
    [InlineData("123.456e+67")]
    [InlineData(".1E4")]
    [InlineData("58.")]
    [InlineData("4e2")]
    [InlineData("-58.00000000001")]
    [InlineData("+.1")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.FLOATING_POINT_LITERAL);
    }
}