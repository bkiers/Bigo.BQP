
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateTableCopyTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_table_copy());
    }
}
    