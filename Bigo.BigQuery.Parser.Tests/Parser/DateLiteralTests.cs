using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DateLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("DATE '2014-09-27'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.date_literal());
    }
}