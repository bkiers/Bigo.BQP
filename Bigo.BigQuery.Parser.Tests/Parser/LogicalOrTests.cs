using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class LogicalOrTests : BaseParserTest
{
    [Theory]
    [InlineData("LOGICAL_OR(x < 3)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.logical_or());
    }
}