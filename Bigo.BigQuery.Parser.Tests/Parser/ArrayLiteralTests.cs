using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ArrayLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("[]")]
    [InlineData("[1]")]
    [InlineData("[1, 2, 3]")]
    [InlineData("['x', 'y', 'xy']")]
    [InlineData("ARRAY[1, 2, 3]")]
    [InlineData("ARRAY<string>['x', 'y', 'xy']")]
    [InlineData("array<int64>[]")]
    [InlineData("array<struct<a int64, b string>>[]")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.array_literal());
    }
}