using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class FunctionCallTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.function_call());
    }
}