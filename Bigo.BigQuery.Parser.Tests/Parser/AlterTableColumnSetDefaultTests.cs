
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableColumnSetDefaultTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_column_set_default());
    }
}