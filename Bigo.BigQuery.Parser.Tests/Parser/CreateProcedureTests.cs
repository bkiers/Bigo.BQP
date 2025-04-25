using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateProcedureTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE PROCEDURE myProject.myDataset.QueryTable()\nBEGIN\n  SELECT * FROM anotherDataset.myTable;\nEND")]
    [InlineData("CREATE PROCEDURE mydataset.AddDelta(INOUT x INT64, delta INT64)\nBEGIN\n  SET x = x + delta;\nEND")]
    [InlineData("CREATE PROCEDURE mydataset.SelectFromTablesAndAppend(\n  target_date DATE, OUT rows_added INT64)\nBEGIN\n  CREATE TEMP TABLE DataForTargetDate AS\n  SELECT t1.id, t1.x, t2.y\n  FROM dataset.partitioned_table1 AS t1\n  JOIN dataset.partitioned_table2 AS t2\n  ON t1.id = t2.id\n  WHERE t1.date = target_date\n    AND t2.date = target_date;\n\n  SET rows_added = (SELECT COUNT(*) FROM DataForTargetDate);\n\n  SELECT id, x, y, target_date  -- note that target_date is a parameter\n  FROM DataForTargetDate;\n\n  DROP TABLE DataForTargetDate;\nEND")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_procedure());
    }
}