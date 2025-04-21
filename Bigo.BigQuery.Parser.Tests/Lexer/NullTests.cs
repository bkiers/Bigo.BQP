using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class NullTests : BaseLexerTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.NULL);
    }
}