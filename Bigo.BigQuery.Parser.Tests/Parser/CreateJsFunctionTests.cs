using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateJsFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE TEMP FUNCTION multiplyInputs(x FLOAT64, y FLOAT64)\nRETURNS FLOAT64\nLANGUAGE js\nAS r\"\"\"\n  return x*y;\n\"\"\"")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_js_function());
    }
}