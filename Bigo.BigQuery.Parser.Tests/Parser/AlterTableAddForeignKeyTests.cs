using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableAddForeignKeyTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE fk_table\nADD CONSTRAINT my_fk_name FOREIGN KEY (u, v)\nREFERENCES pk_table(x, y) NOT ENFORCED")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_add_foreign_key());
    }
}