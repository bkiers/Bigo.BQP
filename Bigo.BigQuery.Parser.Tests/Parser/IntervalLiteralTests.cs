using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class IntervalLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("INTERVAL 5 DAY")]
    [InlineData("INTERVAL -5 DAY")]
    [InlineData("INTERVAL 1 SECOND")]
    [InlineData("INTERVAL -25 MONTH")]
    [InlineData("INTERVAL +90 MINUTE")]
    [InlineData("INTERVAL '10:20:30.52' HOUR TO SECOND")]
    [InlineData("INTERVAL '1-2' YEAR TO MONTH")]
    [InlineData("INTERVAL '1 -15' MONTH TO DAY")]
    [InlineData("INTERVAL '1 5:30' DAY TO MINUTE")]
    [InlineData("INTERVAL '-23-2 10 -12:30' YEAR TO MINUTE")]
    [InlineData("INTERVAL '-23-2 10 -0:30' YEAR TO MINUTE")]
    [InlineData("INTERVAL '-23-2 10 0:-30' YEAR TO MINUTE")]
    [InlineData("INTERVAL '23--2 10 0:30' YEAR TO MINUTE")]
    [InlineData("INTERVAL '-2 10 0:30' MONTH TO MINUTE")]
    [InlineData("interval '-30:10' MINUTE TO SECOND")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.interval_literal());
    }
}