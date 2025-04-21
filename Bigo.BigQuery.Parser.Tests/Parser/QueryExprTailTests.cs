
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class QueryExprTailTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.query_expr_tail());
    }
}