using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class TableFunctionParametersTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.table_function_parameters());
    }
}