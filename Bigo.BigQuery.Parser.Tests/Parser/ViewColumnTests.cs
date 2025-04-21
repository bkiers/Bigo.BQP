
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ViewColumnTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.view_column());
    }
}