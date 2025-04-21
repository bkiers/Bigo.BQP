
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class UnpivotOperatorTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.unpivot_operator());
    }
}