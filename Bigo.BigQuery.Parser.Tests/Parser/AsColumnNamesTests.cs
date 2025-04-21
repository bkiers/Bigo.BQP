
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AsColumnNamesTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.as_column_names());
    }
}
    