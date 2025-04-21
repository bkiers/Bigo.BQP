using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableColumnDropNotNullTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_column_drop_not_null());
    }
}