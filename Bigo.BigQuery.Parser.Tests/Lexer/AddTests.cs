using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class AddTests : BaseLexerTest
{
    [Theory]
    [InlineData("ADD")]
    [InlineData("add")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.ADD);
    }
}