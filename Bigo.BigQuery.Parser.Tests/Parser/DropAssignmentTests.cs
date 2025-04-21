using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropAssignmentTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_assignment());
    }
}