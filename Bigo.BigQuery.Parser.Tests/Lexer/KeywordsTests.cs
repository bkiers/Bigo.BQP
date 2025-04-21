using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class KeywordsTests : BaseLexerTest
{
    [Theory]
    [InlineData("SELECT", BigQueryLexer.SELECT)]
    [InlineData("select", BigQueryLexer.SELECT)]
    public void Test(string input, int expectedType)
    {
        SingleToken(input, expectedType);
    }
}