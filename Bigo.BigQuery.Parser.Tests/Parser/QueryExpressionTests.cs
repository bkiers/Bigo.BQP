using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class QueryExpressionTests : BaseParserTest
{
    [Theory]
    [InlineData("WITH groceries AS\n  (SELECT \"milk\" AS dairy,\n   \"eggs\" AS protein,\n   \"bread\" AS grain)\nSELECT g.*\nFROM groceries AS g")]
    [InlineData("WITH locations AS\n  (SELECT STRUCT(\"Seattle\" AS city, \"Washington\" AS state) AS location\n  UNION ALL\n  SELECT STRUCT(\"Phoenix\" AS city, \"Arizona\" AS state) AS location)\nSELECT l.location.*\nFROM locations l")]
    [InlineData("WITH locations AS\n  (SELECT ARRAY<STRUCT<city STRING, state STRING>>[(\"Seattle\", \"Washington\"),\n    (\"Phoenix\", \"Arizona\")] AS location)\nSELECT l.LOCATION[offset(0)].*\nFROM locations l")]
    [InlineData("WITH orders AS\n  (SELECT 5 as order_id,\n  \"sprocket\" as item_name,\n  200 as quantity)\nSELECT * EXCEPT (order_id)\nFROM orders")]
    [InlineData("WITH orders AS\n  (SELECT 5 as order_id,\n  \"sprocket\" as item_name,\n  200 as quantity)\nSELECT * REPLACE (\"widget\" AS item_name)\nFROM orders")]
    [InlineData("WITH orders AS\n  (SELECT 5 as order_id,\n  \"sprocket\" as item_name,\n  200 as quantity)\nSELECT * REPLACE (quantity/2 AS quantity)\nFROM orders")]
    [InlineData("WITH PlayerStats AS (\n  SELECT ['Coolidge', 'Adams'] as Name, 3 as PointsScored UNION ALL\n  SELECT ['Adams', 'Buchanan'], 0 UNION ALL\n  SELECT ['Coolidge', 'Adams'], 1 UNION ALL\n  SELECT ['Kiran', 'Noam'], 1)\nSELECT DISTINCT Name")]
    [InlineData("WITH\n  PlayerStats AS (\n    SELECT\n      STRUCT<last_name STRING, first_name STRING, age INT64>(\n        'Adams', 'Noam', 20) AS Player,\n      3 AS PointsScored UNION ALL\n    SELECT ('Buchanan', 'Jie', 19), 0 UNION ALL\n    SELECT ('Adams', 'Noam', 20), 4 UNION ALL\n    SELECT ('Buchanan', 'Jie', 19), 13\n  )\nSELECT DISTINCT Player\nFROM PlayerStats")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.query_expression());
    }
}