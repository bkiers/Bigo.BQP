
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ColumnSetsToUnpivotTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.column_sets_to_unpivot());
    }
}
    