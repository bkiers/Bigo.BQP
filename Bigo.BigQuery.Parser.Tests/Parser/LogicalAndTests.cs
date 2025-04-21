using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class LogicalAndTests : BaseParserTest
{
    [Theory]
    [InlineData("LOGICAL_AND(x < 3)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.logical_and());
    }
}