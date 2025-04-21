using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class InfTests : BaseLexerTest
{
    [Theory]
    [InlineData("inf")]
    [InlineData("INF")]
    [InlineData("-inf")]
    [InlineData("+inf")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.INF);
    }
}