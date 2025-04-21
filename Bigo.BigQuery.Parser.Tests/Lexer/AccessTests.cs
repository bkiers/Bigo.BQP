using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class AccessTests : BaseLexerTest
{
    [Theory]
    [InlineData("ACCESS")]
    [InlineData("access")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.ACCESS);
    }
}