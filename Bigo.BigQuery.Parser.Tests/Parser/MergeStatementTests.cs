using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class MergeStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("MERGE dataset.DetailedInventory T\nUSING dataset.Inventory S\nON T.product = S.product\nWHEN NOT MATCHED AND quantity < 20 THEN\n  INSERT(product, quantity, supply_constrained, comments)\n  VALUES(product, quantity, true, ARRAY<STRUCT<created DATE, comment STRING>>[(DATE('2016-01-01'), 'comment1')])\nWHEN NOT MATCHED THEN\n  INSERT(product, quantity, supply_constrained)\n  VALUES(product, quantity, false)\n")]
    [InlineData("MERGE dataset.Inventory T\nUSING dataset.NewArrivals S\nON T.product = S.product\nWHEN MATCHED THEN\n  UPDATE SET quantity = T.quantity + S.quantity\nWHEN NOT MATCHED THEN\n  INSERT (product, quantity) VALUES(product, quantity)\n")]
    [InlineData("MERGE dataset.NewArrivals T\nUSING (SELECT * FROM dataset.NewArrivals WHERE warehouse <> 'warehouse #2') S\nON T.product = S.product\nWHEN MATCHED AND T.warehouse = 'warehouse #1' THEN\n  UPDATE SET quantity = T.quantity + 20\nWHEN MATCHED THEN\n  DELETE\n")]
    [InlineData("MERGE dataset.Inventory T\nUSING dataset.NewArrivals S\nON FALSE\nWHEN NOT MATCHED AND product LIKE '%washer%' THEN\n  INSERT (product, quantity) VALUES(product, quantity)\nWHEN NOT MATCHED BY SOURCE AND product LIKE '%washer%' THEN\n  DELETE\n")]
    [InlineData("MERGE dataset.DetailedInventory T\nUSING dataset.Inventory S\nON T.product = S.product\nWHEN MATCHED AND S.quantity < (SELECT AVG(quantity) FROM dataset.Inventory) THEN\n  UPDATE SET comments = ARRAY_CONCAT(comments, ARRAY<STRUCT<created DATE, comment STRING>>[(CAST('2016-02-01' AS DATE), 'comment2')])\n")]
    [InlineData("MERGE dataset.Inventory T\nUSING (SELECT product, quantity, state FROM dataset.NewArrivals t1 JOIN dataset.Warehouse t2 ON t1.warehouse = t2.warehouse) S\nON T.product = S.product\nWHEN MATCHED AND state = 'CA' THEN\n  UPDATE SET quantity = T.quantity + S.quantity\nWHEN MATCHED THEN\n  DELETE\n")]
    [InlineData("MERGE dataset.Inventory T\nUSING dataset.NewArrivals S\nON T.product = S.product\nWHEN MATCHED THEN\n  UPDATE SET quantity = T.quantity + S.quantity\n")]
    [InlineData("MERGE dataset.NewArrivals\nUSING (SELECT * FROM UNNEST([('microwave', 10, 'warehouse #1'),\n                             ('dryer', 30, 'warehouse #1'),\n                             ('oven', 20, 'warehouse #2')]))\nON FALSE\nWHEN NOT MATCHED THEN\n  INSERT ROW\nWHEN NOT MATCHED BY SOURCE THEN\n  DELETE\n")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.merge_statement());
    }
}