using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class SingleStatementTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.single_statement());
    }
}