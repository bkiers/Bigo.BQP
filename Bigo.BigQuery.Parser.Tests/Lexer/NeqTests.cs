using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class NeqTests : BaseLexerTest
{
    [Theory]
    [InlineData("<>")]
    [InlineData("!=")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.NEQ);
    }
}