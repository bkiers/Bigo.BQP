using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateMaterializedViewAsReplicaTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE MATERIALIZED VIEW `myproject.bq_dataset.mv_replica`\nOPTIONS(\n  replication_interval_seconds=600\n)\nAS REPLICA OF `myproject.s3_dataset.my_s3_mv`")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_materialized_view_as_replica());
    }
}