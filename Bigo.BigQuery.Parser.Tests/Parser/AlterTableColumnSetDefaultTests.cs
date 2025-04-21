using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableColumnSetDefaultTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\nALTER COLUMN mycolumn\nSET DEFAULT CURRENT_TIME()")]
    [InlineData("ALTER TABLE IF EXISTS mydataset.mytable\nALTER COLUMN IF EXISTS mycolumn\nSET DEFAULT CURRENT_TIME()")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_column_set_default());
    }
}