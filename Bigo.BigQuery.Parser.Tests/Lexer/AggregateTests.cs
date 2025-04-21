using BigO.BigQuery.Parser;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public class AggregateTests : BaseLexerTest
{
    [Theory]
    [InlineData("AGGREGATE")]
    [InlineData("Aggregate")]
    public void Test(string input)
    {
        SingleToken(input, BigQueryLexer.AGGREGATE);
    }
}