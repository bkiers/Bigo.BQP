using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableRenameTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable RENAME TO mynewtable")]
    [InlineData("ALTER TABLE if exists oldtable RENAME TO newtable")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_rename());
    }
}