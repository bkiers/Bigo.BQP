
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class GroupableItemSetTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.groupable_item_set());
    }
}
    