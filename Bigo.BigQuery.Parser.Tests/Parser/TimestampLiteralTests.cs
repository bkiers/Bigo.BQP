using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class TimestampLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("TIMESTAMP '2014-09-27 12:30:00.45-08'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.timestamp_literal());
    }
}