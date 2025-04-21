using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DatetimePartTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.datetime_part());
    }
}