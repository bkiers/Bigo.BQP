using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class GroupingTests : BaseParserTest
{
    [Theory]
    [InlineData("GROUPING(product_type)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.grouping());
    }
}