using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class YearTests : BaseLexerTest
{
    [Theory]
    [InlineData("YEAR")]
    [InlineData("year")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.YEAR);
    }
}