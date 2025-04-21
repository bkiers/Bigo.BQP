
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CrossJoinOperatorTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.cross_join_operator());
    }
}