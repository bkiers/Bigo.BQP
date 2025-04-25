using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropExternalTableTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP EXTERNAL TABLE mydataset.external_table")]
    [InlineData("DROP EXTERNAL TABLE IF EXISTS mydataset.external_table")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_external_table());
    }
}