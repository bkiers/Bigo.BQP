using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableSetDefaultCollateTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\nSET DEFAULT COLLATE ''")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_set_default_collate());
    }
}