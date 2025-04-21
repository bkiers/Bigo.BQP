using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class StringLiteralTests : BaseLexerTest
{
    [Theory]
    [InlineData("\"abc\"")]
    [InlineData("\"it's\"")]
    [InlineData("'it\\'s'")]
    [InlineData("'Title: \"Boy\"'")]
    [InlineData("\"\"\"abc\"\"\"")]
    [InlineData("'''it's'''")]
    [InlineData("'''Title:\"Boy\"'''")]
    [InlineData("'''two\nlines'''")]
    [InlineData("'''why\\?'''")]
    [InlineData("'\\uABCD'")]
    [InlineData("'\\U1234ABCD'")]
    [InlineData("'\\xAB\\XCD'")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.STRING_LITERAL);
    }
}