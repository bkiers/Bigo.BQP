using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DatetimeLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("DATETIME '2014-09-27T12:30:00.45'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.datetime_literal());
    }
}