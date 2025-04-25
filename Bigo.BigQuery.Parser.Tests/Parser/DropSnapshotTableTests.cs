using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropSnapshotTableTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP SNAPSHOT TABLE mydataset.mytablesnapshot")]
    [InlineData("DROP SNAPSHOT TABLE IF EXISTS mydataset.mytablesnapshot")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_snapshot_table());
    }
}