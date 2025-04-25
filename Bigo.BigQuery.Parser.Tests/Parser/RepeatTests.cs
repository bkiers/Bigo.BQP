using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class RepeatTests : BaseParserTest
{
    [Theory]
    [InlineData("REPEAT SELECT 1; SELECT 2 UNTIL FALSE END REPEAT")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.repeat());
    }
}