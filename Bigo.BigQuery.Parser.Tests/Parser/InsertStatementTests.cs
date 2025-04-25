using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class InsertStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("INSERT dataset.Inventory (product, quantity)\nVALUES('top load washer', 10),\n      ('front load washer', 20),\n      ('dryer', 30),\n      ('refrigerator', 10),\n      ('microwave', 20),\n      ('dishwasher', 30),\n      ('oven', 5)\n")]
    [InlineData("INSERT dataset.NewArrivals (product, quantity, warehouse)\nVALUES('top load washer', DEFAULT, 'warehouse #1'),\n      ('dryer', 200, 'warehouse #2'),\n      ('oven', 300, 'warehouse #3')")]
    [InlineData("INSERT dataset.Warehouse (warehouse, state)\nSELECT *\nFROM UNNEST([('warehouse #1', 'WA'),\n      ('warehouse #2', 'CA'),\n      ('warehouse #3', 'WA')])\n")]
    [InlineData("INSERT dataset.Warehouse (warehouse, state)\nWITH w AS (\n  SELECT ARRAY<STRUCT<warehouse string, state string>>\n      [('warehouse #1', 'WA'),\n       ('warehouse #2', 'CA'),\n       ('warehouse #3', 'WA')] col\n)\nSELECT warehouse, state FROM w, UNNEST(w.col)\n")]
    [InlineData("INSERT dataset.DetailedInventory (product, quantity, supply_constrained)\nSELECT product, quantity, false\nFROM dataset.Inventory\n")]
    [InlineData("INSERT dataset.DetailedInventory (product, quantity)\nVALUES('countertop microwave',\n  (SELECT quantity FROM dataset.DetailedInventory\n   WHERE product = 'microwave'))\n")]
    [InlineData("INSERT dataset.Warehouse VALUES('warehouse #4', 'WA'), ('warehouse #5', 'NY')\n")]
    [InlineData("INSERT dataset.DetailedInventory\nVALUES('top load washer', 10, FALSE, [(CURRENT_DATE, \"comment1\")], (\"white\",\"1 year\",(30,40,28))),\n      ('front load washer', 20, FALSE, [(CURRENT_DATE, \"comment1\")], (\"beige\",\"1 year\",(35,45,30)))\n")]
    [InlineData("INSERT INTO dataset.table1 (names)\nVALUES ([\"name1\",\"name2\"])")]
    [InlineData("INSERT mydataset.my_range_table (emp_id, dept_id, duration)\nVALUES(10, 1000, RANGE<DATE> '[2010-01-10, 2010-03-10)'),\n      (10, 2000, RANGE<DATE> '[2010-03-10, 2010-07-15)'),\n      (10, 2000, RANGE<DATE> '[2010-06-15, 2010-08-18)'),\n      (20, 2000, RANGE<DATE> '[2010-03-10, 2010-07-20)'),\n      (20, 1000, RANGE<DATE> '[2020-05-10, 2020-09-20)')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.insert_statement());
    }
}