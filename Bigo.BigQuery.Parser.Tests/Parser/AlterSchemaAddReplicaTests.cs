using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterSchemaAddReplicaTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER SCHEMA cross_region_dataset ADD REPLICA `EU` OPTIONS(location=`eu`)")]
    [InlineData("ALTER SCHEMA IF EXISTS cross_region_dataset ADD REPLICA `EU` OPTIONS(location=`eu`)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_schema_add_replica());
    }
}