using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class AllTests : BaseLexerTest
{
    [Theory]
    [InlineData("ALL")]
    [InlineData("all")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.ALL);
    }
}