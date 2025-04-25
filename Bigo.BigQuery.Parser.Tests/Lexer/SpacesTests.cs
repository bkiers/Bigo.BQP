using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class SpacesTests : BaseLexerTest
{
    [Theory]
    [InlineData("  \r \t \n  ")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.SPACES, Antlr4.Runtime.Lexer.Hidden);
    }
}