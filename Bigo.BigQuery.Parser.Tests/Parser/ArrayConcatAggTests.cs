using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ArrayConcatAggTests : BaseParserTest
{
    [Theory]
    [InlineData("ARRAY_CONCAT_AGG(x)")]
    [InlineData("ARRAY_CONCAT_AGG(x ORDER BY ARRAY_LENGTH(x))")]
    [InlineData("ARRAY_CONCAT_AGG(x LIMIT 2)")]
    [InlineData("ARRAY_CONCAT_AGG(x ORDER BY ARRAY_LENGTH(x) LIMIT 2)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.array_concat_agg());
    }
}