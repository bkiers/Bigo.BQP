
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class GroupBySpecificationTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.group_by_specification());
    }
}