using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class BigNumericLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("BIGNUMERIC '12345678987654321'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.big_numeric_literal());
    }
}