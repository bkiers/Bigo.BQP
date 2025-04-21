using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableAddConstraintTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_add_constraint());
    }
}