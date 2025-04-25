using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class QuotedIdentifierTests : BaseLexerTest
{
    [Theory]
    [InlineData("`foo bar @ baz`")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.QUOTED_IDENTIFIER);
    }
}