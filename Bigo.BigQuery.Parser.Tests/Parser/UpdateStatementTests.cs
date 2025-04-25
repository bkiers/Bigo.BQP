using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class UpdateStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("UPDATE dataset.Inventory\nSET quantity = quantity - 10,\n    supply_constrained = DEFAULT\nWHERE product like '%washer%'\n")]
    [InlineData("UPDATE dataset.Inventory\nSET quantity = quantity +\n  (SELECT quantity FROM dataset.NewArrivals\n   WHERE Inventory.product = NewArrivals.product),\n    supply_constrained = false\nWHERE product IN (SELECT product FROM dataset.NewArrivals)\n")]
    [InlineData("UPDATE dataset.Inventory i\nSET quantity = i.quantity + n.quantity,\n    supply_constrained = false\nFROM dataset.NewArrivals n\nWHERE i.product = n.product\n")]
    [InlineData("UPDATE dataset.DetailedInventory\nSET specifications.color = 'white',\n    specifications.warranty = '1 year'\nWHERE product like '%washer%'\n")]
    [InlineData("UPDATE dataset.DetailedInventory\nSET specifications\n   = STRUCT<color STRING, warranty STRING,\n   dimensions STRUCT<depth FLOAT64, height FLOAT64, width FLOAT64>>('white', '1 year', NULL)\nWHERE product like '%washer%'\n")]
    [InlineData("UPDATE dataset.DetailedInventory\nSET comments = ARRAY(\n  SELECT comment FROM UNNEST(comments) AS comment\n  UNION ALL\n  SELECT (CAST('2016-01-01' AS DATE), 'comment1')\n)\nWHERE product like '%washer%'\n")]
    [InlineData("UPDATE dataset.DetailedInventory\nSET comments = ARRAY_CONCAT(comments,\n  ARRAY<STRUCT<created DATE, comment STRING>>[(CAST('2016-01-01' AS DATE), 'comment1')])\nWHERE product like '%washer%'\n")]
    [InlineData("UPDATE dataset.DetailedInventory\nSET comments = ARRAY(\n  SELECT comment FROM UNNEST(comments) AS comment\n  UNION ALL\n  SELECT (CAST('2016-01-01' AS DATE), 'comment2')\n)\nWHERE true")]
    [InlineData("UPDATE dataset.DetailedInventory\nSET comments = ARRAY(\n  SELECT c FROM UNNEST(comments) AS c\n  WHERE c.comment NOT LIKE '%comment2%'\n)\nWHERE true\n")]
    [InlineData("UPDATE dataset.DetailedInventory\nSET supply_constrained = true\nFROM dataset.NewArrivals, dataset.Warehouse\nWHERE DetailedInventory.product = NewArrivals.product AND\n      NewArrivals.warehouse = Warehouse.warehouse AND\n      Warehouse.state = 'WA'\n")]
    [InlineData("UPDATE dataset.DetailedInventory\nSET supply_constrained = true\nFROM dataset.NewArrivals\nINNER JOIN dataset.Warehouse\nON NewArrivals.warehouse = Warehouse.warehouse\nWHERE DetailedInventory.product = NewArrivals.product AND\n      Warehouse.state = 'WA'\n")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.update_statement());
    }
}