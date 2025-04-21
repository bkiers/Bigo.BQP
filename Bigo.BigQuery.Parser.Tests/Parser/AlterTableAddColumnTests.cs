using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableAddColumnTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\n  ADD COLUMN A STRING,\n  ADD COLUMN IF NOT EXISTS B GEOGRAPHY,\n  ADD COLUMN C ARRAY <NUMERIC>,\n  ADD COLUMN D DATE OPTIONS(description=\"my description\")")]
    [InlineData("ALTER TABLE mydataset.mytable\n   ADD COLUMN A STRUCT<\n       B GEOGRAPHY,\n       C ARRAY <INT64>,\n       D INT64 NOT NULL,\n       E TIMESTAMP OPTIONS(description=\"creation time\")\n       >")]
    [InlineData("ALTER TABLE mydataset.mytable\nADD COLUMN word STRING COLLATE 'und:ci'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_add_column());
    }
}