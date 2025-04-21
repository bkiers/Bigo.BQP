using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterSchemaDropReplicaTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER SCHEMA cross_region_dataset\nDROP REPLICA `us-east4`")]
    [InlineData("ALTER SCHEMA IF EXISTS cross_region_dataset\nDROP REPLICA `us-east4`")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_schema_drop_replica());
    }
}