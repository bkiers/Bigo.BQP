using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableColumnDropDefaultTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\nALTER COLUMN mycolumn\nDROP DEFAULT")]
    [InlineData("ALTER TABLE IF EXISTS mydataset.mytable\nALTER COLUMN IF EXISTS mycolumn\nDROP DEFAULT")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_column_drop_default());
    }
}