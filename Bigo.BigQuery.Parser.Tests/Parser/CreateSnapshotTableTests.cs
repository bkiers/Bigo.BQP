using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateSnapshotTableTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE SNAPSHOT TABLE `myproject.mydataset.mytablesnapshot`\nCLONE `myproject.mydataset.mytable`\nOPTIONS(\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 48 HOUR),\n  friendly_name=\"my_table_snapshot\",\n  description=\"A table snapshot that expires in 2 days\",\n  labels=[(\"org_unit\", \"development\")]\n)\n")]
    [InlineData("CREATE SNAPSHOT TABLE IF NOT EXISTS `myproject.mydataset.mytablesnapshot`\nCLONE `myproject.mydataset.mytable`\nOPTIONS(\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 48 HOUR),\n  friendly_name=\"my_table_snapshot\",\n  description=\"A table snapshot that expires in 2 days\"\n  labels=[(\"org_unit\", \"development\")]\n)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_snapshot_table());
    }
}