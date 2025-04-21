using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class RawStringLiteralTests : BaseLexerTest
{
    [Theory]
    [InlineData("r\"abc+\"")]
    [InlineData("r'''abc+'''")]
    [InlineData("r\"\"\"abc+\"\"\"")]
    [InlineData("r'f\\(abc,(.*),def\\)'")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.RAW_STRING_LITERAL);
    }
}