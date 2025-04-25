using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class WhileTests : BaseParserTest
{
    [Theory]
    [InlineData("WHILE true DO select 1; END WHILE")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.@while());
    }
}