using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class TruncateTableStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("TRUNCATE TABLE dataset.Inventory")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.truncate_table_statement());
    }
}