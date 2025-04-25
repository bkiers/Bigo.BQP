using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AsColumnNamesTests : BaseParserTest
{
    [Theory]
    [InlineData("A as a")]
    [InlineData("A as a, B as b, C as c")]
    [InlineData("aaa.A as a, bbb.B as b")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.as_column_names());
    }
}