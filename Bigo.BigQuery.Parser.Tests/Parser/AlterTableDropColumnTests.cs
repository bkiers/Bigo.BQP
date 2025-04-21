using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableDropColumnTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\n  DROP COLUMN A,\n  DROP COLUMN IF EXISTS B")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_drop_column());
    }
}