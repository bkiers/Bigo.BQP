using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class SelectTests : BaseParserTest
{
    [Theory]
    [InlineData("select 1")]
    [InlineData("select *")]
    [InlineData("select all as struct *")]
    [InlineData("SELECT * FROM (SELECT \"apple\" AS fruit, \"carrot\" AS vegetable)")]
    [InlineData("SELECT g.* FROM groceries AS g")]
    [InlineData("SELECT l.location.* FROM locations l")]
    [InlineData("SELECT l.LOCATION[fn(0)].* FROM locations l")]
    [InlineData("SELECT * EXCEPT (order_id) FROM orders")]
    [InlineData("SELECT * REPLACE (\"widget\" AS item_name) FROM orders")]
    [InlineData("SELECT ['Coolidge', 'Adams'] as Names, 3 as PointsScored")]
    [InlineData("SELECT ['Adams', 'Buchanan'], 0")]
    [InlineData("SELECT ['Coolidge', 'Adams'], 1")]
    [InlineData("SELECT ['Kiran', 'Noam'], 1")]
    [InlineData("SELECT DISTINCT Names")]
    [InlineData("SELECT ARRAY(SELECT AS STRUCT 1 a, 2 b)")]
    [InlineData("SELECT AS VALUE STRUCT(1 AS a, 2 AS b) xyz")]
    [InlineData("SELECT * FROM Roster")]
    [InlineData("SELECT * FROM dataset.Roster")]
    [InlineData("SELECT * FROM project.dataset.Roster")]
    [InlineData("SELECT * FROM t FOR SYSTEM_TIME AS OF TIMESTAMP_SUB(CURRENT_TIMESTAMP(), INTERVAL 1 HOUR)")]
    [InlineData("SELECT * FROM t1 WHERE t1.a IN (SELECT t2.a FROM t2 FOR SYSTEM_TIME AS OF t1.timestamp_column)")]
    [InlineData("SELECT 'Hamlet' title, 'William Shakespeare' author")]
    [InlineData("SELECT 'Hamlet' title, DATE '1603-01-01' release_date")]
    [InlineData("SELECT * FROM books FOR SYSTEM_TIME AS OF before_replace_timestamp")]
    [InlineData("SELECT * FROM t1 FOR SYSTEM_TIME AS OF TIMESTAMP_SUB(CURRENT_TIMESTAMP(), INTERVAL 1 DAY)")]
    [InlineData("SELECT * FROM T1 t1, t1.array_column")]
    [InlineData("SELECT * FROM T1 t1, t1.struct_column.array_field")]
    [InlineData("SELECT (SELECT ARRAY_AGG(c) FROM t1.array_column c) FROM T1 t1")]
    [InlineData("SELECT a.struct_field1 FROM T1 t1, t1.array_of_structs a")]
    [InlineData("SELECT (SELECT STRING_AGG(a.struct_field1) FROM t1.array_of_structs a) FROM T1 t1")]
    [InlineData("SELECT DISTINCT * FROM subQ2")]
    [InlineData("SELECT * FROM UNNEST ([10,20,30]) as numbers WITH OFFSET")]
    [InlineData("SELECT * FROM UNNEST(ARRAY<STRUCT<x INT64, y STRING, z STRUCT<a INT64, b INT64>>>[(1, 'foo', (10, 11)), (3, 'bar', (20, 21))])")]
    [InlineData("SELECT FORMAT(\"%T\", [1, NULL, 3]) as numbers")]
    [InlineData("SELECT CAST(5 AS INT64) AS a, CAST(37 AS FLOAT64) AS b, 406 AS c")]
    [InlineData("SELECT item FROM Produce WHERE Produce.category = 'vegetable' QUALIFY RANK() OVER (PARTITION BY category ORDER BY purchases DESC) <= 3")]
    [InlineData("SELECT SUM(PointsScored) AS total_points, LastName FROM PlayerStats GROUP BY LastName")]
    [InlineData("SELECT SUM(PointsScored) AS total_points, LastName, FirstName FROM PlayerStats GROUP BY LastName, FirstName")]
    [InlineData("SELECT LastName FROM Roster GROUP BY LastName HAVING SUM(PointsScored) > 15")]
    [InlineData("SELECT item, RANK() OVER (PARTITION BY category ORDER BY purchases DESC) as rank FROM Produce WHERE Produce.category = 'vegetable' QUALIFY rank <= 3")]
    [InlineData("SELECT item, purchases, category, LAST_VALUE(item) OVER (item_window) AS most_popular FROM Produce WINDOW item_window AS (PARTITION BY category ORDER BY purchases ROWS BETWEEN 2 PRECEDING AND 2 FOLLOWING)")]
    [InlineData("SELECT item, purchases, category, LAST_VALUE(item) OVER (c ROWS BETWEEN 2 PRECEDING AND 2 FOLLOWING) AS most_popular FROM Produce WINDOW a AS (PARTITION BY category), b AS (a ORDER BY purchases), c AS b")]
    [InlineData("SELECT 101 AS id, \"pencil\" AS item, 24 AS quantity")]
    [InlineData("SELECT WITH DIFFERENTIAL_PRIVACY OPTIONS(epsilon=10, delta=.01, max_groups_contributed=2, privacy_unit_column=id) item, AVG(quantity, contribution_bounds_per_group => (0,100)) AS average_quantity FROM professors GROUP BY item")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.select());
    }
}