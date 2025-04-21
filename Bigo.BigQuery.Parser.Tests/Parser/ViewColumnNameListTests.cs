using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ViewColumnNameListTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.view_column_name_list());
    }
}