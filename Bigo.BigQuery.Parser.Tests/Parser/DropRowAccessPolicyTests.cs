using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropRowAccessPolicyTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP ROW ACCESS POLICY my_row_filter ON project.dataset.my_table")]
    [InlineData("DROP ROW ACCESS POLICY IF EXISTS my_row_filter ON project.dataset.my_table")]
    [InlineData("DROP ALL ROW ACCESS POLICIES ON project.dataset.my_table")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_row_access_policy());
    }
}