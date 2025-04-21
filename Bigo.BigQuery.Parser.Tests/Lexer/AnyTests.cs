using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class AnyTests : BaseLexerTest
{
    [Theory]
    [InlineData("ANY")]
    [InlineData("any")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.ANY);
    }
}