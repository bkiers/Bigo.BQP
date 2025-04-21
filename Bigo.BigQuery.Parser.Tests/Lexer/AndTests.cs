using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class AndTests : BaseLexerTest
{
    [Theory]
    [InlineData("AND")]
    [InlineData("and")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.AND);
    }
}