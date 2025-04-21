using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterMaterializedViewTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER MATERIALIZED VIEW mydataset.my_mv\nSET OPTIONS (\n  enable_refresh=true,\n  refresh_interval_minutes=20\n)")]
    [InlineData("ALTER MATERIALIZED VIEW IF EXISTS mydataset.my_mv\nSET OPTIONS (\n  enable_refresh=true,\n  refresh_interval_minutes=20\n)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_materialized_view());
    }
}