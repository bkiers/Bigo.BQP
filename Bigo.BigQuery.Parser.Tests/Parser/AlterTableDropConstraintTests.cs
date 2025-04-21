using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableDropConstraintTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mytable DROP CONSTRAINT myConstraint")]
    [InlineData("ALTER TABLE mu.foo.mytable DROP CONSTRAINT IF EXISTS myConstraint")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_drop_constraint());
    }
}