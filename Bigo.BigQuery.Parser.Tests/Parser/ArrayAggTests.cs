using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ArrayAggTests : BaseParserTest
{
    [Theory]
    [InlineData("ARRAY_AGG(x)")]
    [InlineData("ARRAY_AGG(DISTINCT x)")]
    [InlineData("ARRAY_AGG(x IGNORE NULLS)")]
    [InlineData("ARRAY_AGG(x ORDER BY ABS(x))")]
    [InlineData("ARRAY_AGG(x LIMIT 5)")]
    [InlineData("ARRAY_AGG(DISTINCT x ORDER BY x)")]
    [InlineData("ARRAY_AGG(x) OVER (ORDER BY ABS(x))")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.array_agg());
    }
}