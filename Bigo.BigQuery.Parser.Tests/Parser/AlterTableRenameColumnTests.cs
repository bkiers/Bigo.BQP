using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableRenameColumnTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\n  RENAME COLUMN A TO columnA,\n  RENAME COLUMN IF EXISTS B TO columnB")]
    [InlineData("ALTER TABLE mydataset.mytable\n  RENAME COLUMN columnA TO temp_col,\n  RENAME COLUMN columnB TO columnA,\n  RENAME COLUMN temp_col TO columnB")]
    [InlineData("ALTER TABLE IF EXISTS mydataset.mytable\n  RENAME COLUMN columnA TO temp_col,\n  RENAME COLUMN columnB TO columnA,\n  RENAME COLUMN temp_col TO columnB")]
    [InlineData("ALTER TABLE IF EXISTS mytable\n  RENAME COLUMN IF EXISTS A TO columnA,\n  RENAME COLUMN IF EXISTS B TO columnB")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_rename_column());
    }
}