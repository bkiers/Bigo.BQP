using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateStoredProcedureTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_stored_procedure());
    }
}