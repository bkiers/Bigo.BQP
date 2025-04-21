using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableAddPrimaryKeyTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE pk_table ADD PRIMARY KEY (x,y) NOT ENFORCED")]
    [InlineData("ALTER TABLE mu.pk_table ADD PRIMARY KEY (x,y) NOT ENFORCED")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_add_primary_key());
    }
}