using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class ArrayAggTests : BaseLexerTest
{
    [Theory]
    [InlineData("ARRAY_AGG")]
    [InlineData("Array_Agg")]
    [InlineData("array_agg")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.ARRAY_AGG);
    }
}