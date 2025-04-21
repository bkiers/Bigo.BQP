
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class RecursiveUnionOperationTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.recursive_union_operation());
    }
}
    