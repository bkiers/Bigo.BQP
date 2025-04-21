using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE FUNCTION mydataset.multiplyInputs(x FLOAT64, y FLOAT64)\nRETURNS FLOAT64\nAS (x * y)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_function());
    }
}