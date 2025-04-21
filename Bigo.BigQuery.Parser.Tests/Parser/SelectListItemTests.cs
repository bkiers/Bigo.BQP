using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class SelectListItemTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.select_list_item());
    }
}