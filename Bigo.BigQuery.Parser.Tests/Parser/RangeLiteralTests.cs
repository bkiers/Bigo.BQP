using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class RangeLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("RANGE<DATE> '[2020-01-01, 2020-12-31)'")]
    [InlineData("RANGE<DATETIME> '[2020-01-01 12:00:00, 2020-12-31 12:00:00)'")]
    [InlineData("RANGE<TIMESTAMP> '[2020-10-01 12:00:00+08, 2020-12-31 12:00:00+08)'")]
    [InlineData("RANGE<DATE> '[2020-01-01, NULL)'")]
    [InlineData("RANGE<DATE> '[NULL, NULL)'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.range_literal());
    }
}