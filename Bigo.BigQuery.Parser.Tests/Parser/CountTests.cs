using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CountTests : BaseParserTest
{
    [Theory]
    [InlineData("COUNT(*)")]
    [InlineData("COUNT(x)")]
    [InlineData("COUNT(DISTINCT x)")]
    [InlineData("COUNT(*) OVER (PARTITION BY MOD(x, 3))")]
    [InlineData("COUNT(DISTINCT x) OVER (PARTITION BY MOD(x, 3))")]
    [InlineData("COUNT(DISTINCT IF(x > 0, x, NULL))")]
    [InlineData("COUNT(DISTINCT IF(event_type = 'FAILURE', event_date, NULL))")]
    [InlineData("COUNT(DISTINCT IF(id IN (SELECT id FROM customers), id, NULL))")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.count());
    }
}