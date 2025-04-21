using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class SetOperationTailTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.set_operation_tail());
    }
}