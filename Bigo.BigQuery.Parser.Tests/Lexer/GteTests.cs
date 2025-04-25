using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class GteTests : BaseLexerTest
{
    [Theory]
    [InlineData(">=")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.GTE);
    }
}