
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ConditionJoinOperatorTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.condition_join_operator());
    }
}
    