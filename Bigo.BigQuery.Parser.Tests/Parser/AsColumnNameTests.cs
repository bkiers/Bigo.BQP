using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AsColumnNameTests : BaseParserTest
{
    [Theory]
    [InlineData("count AS ct")]
    [InlineData("a.b.count AS ct")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.as_column_name());
    }
}