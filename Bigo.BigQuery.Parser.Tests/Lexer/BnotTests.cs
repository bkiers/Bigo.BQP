using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class BnotTests : BaseLexerTest
{
    [Theory]
    [InlineData("~")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.BNOT);
    }
}