using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropExternalTableTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_external_table());
    }
}