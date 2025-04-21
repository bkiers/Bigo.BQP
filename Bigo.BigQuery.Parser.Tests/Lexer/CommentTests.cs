using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class CommentTests : BaseLexerTest
{
    [Theory]
    [InlineData("-- fubar")]
    [InlineData("--")]
    [InlineData("# fubar")]
    [InlineData("/* fu \n bar */")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.COMMENT, Antlr4.Runtime.Lexer.Hidden);
    }
}