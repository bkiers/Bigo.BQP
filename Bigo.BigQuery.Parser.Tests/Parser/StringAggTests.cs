using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class StringAggTests : BaseParserTest
{
    [Theory]
    [InlineData("STRING_AGG(fruit)")]
    [InlineData("STRING_AGG(fruit, \" & \")")]
    [InlineData("STRING_AGG(DISTINCT fruit, \" & \")")]
    [InlineData("STRING_AGG(fruit, \" & \" ORDER BY LENGTH(fruit))")]
    [InlineData("STRING_AGG(fruit, \" & \" LIMIT 2)")]
    [InlineData("STRING_AGG(DISTINCT fruit, \" & \" ORDER BY fruit DESC LIMIT 2)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.string_agg());
    }
}