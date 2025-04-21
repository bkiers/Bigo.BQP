
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ColumnsToUnpivotTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.columns_to_unpivot());
    }
}
    