using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateMaterializedViewTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE MATERIALIZED VIEW myProject.myDataset.myView AS SELECT * FROM anotherDataset.myTable")]
    [InlineData("CREATE MATERIALIZED VIEW `myproject.mydataset.new_mv`\nOPTIONS(\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 48 HOUR),\n  friendly_name=\"new_mv\",\n  description=\"a materialized view that expires in 2 days\",\n  labels=[(\"org_unit\", \"development\")],\n  enable_refresh=true,\n  refresh_interval_minutes=20\n)\nAS SELECT column_1, SUM(column_2) AS sum_2, AVG(column_3) AS avg_3\nFROM `myproject.mydataset.mytable`\nGROUP BY column_1")]
    [InlineData("CREATE MATERIALIZED VIEW IF NOT EXISTS `myproject.mydataset.new_mv`\nOPTIONS(\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 48 HOUR),\n  friendly_name=\"new_mv\",\n  description=\"a view that expires in 2 days\",\n  labels=[(\"org_unit\", \"development\")],\n  enable_refresh=false\n)\nAS SELECT column_1, column_2, column_3 FROM `myproject.mydataset.mytable`")]
    [InlineData("CREATE MATERIALIZED VIEW `myproject.mydataset.new_mv`\nPARTITION BY DATE(col_datetime)\nCLUSTER BY col_int\nAS SELECT col_int, col_datetime, COUNT(1) as cnt\n   FROM `myproject.mydataset.mv_base_table`\n   GROUP BY col_int, col_datetime")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_materialized_view());
    }
}