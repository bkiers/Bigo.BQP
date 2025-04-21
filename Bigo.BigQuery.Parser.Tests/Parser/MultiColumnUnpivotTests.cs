using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class MultiColumnUnpivotTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.multi_column_unpivot());
    }
}