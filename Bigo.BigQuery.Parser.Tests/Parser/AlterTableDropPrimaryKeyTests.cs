using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableDropPrimaryKeyTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE myTable\nDROP PRIMARY KEY")]
    [InlineData("ALTER TABLE myTable\nDROP PRIMARY KEY IF EXISTS")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_drop_primary_key());
    }
}