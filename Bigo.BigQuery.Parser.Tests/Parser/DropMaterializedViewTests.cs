using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropMaterializedViewTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP MATERIALIZED VIEW mydataset.my_mv")]
    [InlineData("DROP MATERIALIZED VIEW IF EXISTS mydataset.my_mv")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_materialized_view());
    }
}