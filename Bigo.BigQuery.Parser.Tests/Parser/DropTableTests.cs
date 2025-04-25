using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropTableTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP TABLE mytable")]
    [InlineData("DROP TABLE IF EXISTS mydataset.mytable")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_table());
    }
}