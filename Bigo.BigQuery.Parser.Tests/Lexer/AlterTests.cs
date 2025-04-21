using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class AlterTests : BaseLexerTest
{
    [Theory]
    [InlineData("ALTER")]
    [InlineData("alter")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.ALTER);
    }
}