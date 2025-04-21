
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DifferentialPrivacyClauseTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.differential_privacy_clause());
    }
}
    