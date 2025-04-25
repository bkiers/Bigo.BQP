using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class UnquotedIdentifierTests : BaseLexerTest
{
    [Theory]
    [InlineData("foobar")]
    [InlineData("@@system_var")]
    [InlineData("@param")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.UNQUOTED_IDENTIFIER);
    }
}