using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterViewTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER VIEW mydataset.myview\nSET OPTIONS (\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 7 DAY),\n  description=\"View that expires seven days from now\"\n)")]
    [InlineData("ALTER VIEW IF EXISTS mydataset.myview\nSET OPTIONS (\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 7 DAY),\n  description=\"View that expires seven days from now\"\n)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_view());
    }
}