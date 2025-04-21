using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropSnapshotTableTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_snapshot_table());
    }
}