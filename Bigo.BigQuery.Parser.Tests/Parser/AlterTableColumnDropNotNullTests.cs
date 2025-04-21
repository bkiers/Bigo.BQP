using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableColumnDropNotNullTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\nALTER COLUMN mycolumn\nDROP NOT NULL")]
    [InlineData("ALTER TABLE IF EXISTS mydataset.mytable\nALTER COLUMN IF EXISTS mycolumn\nDROP NOT NULL")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_column_drop_not_null());
    }
}