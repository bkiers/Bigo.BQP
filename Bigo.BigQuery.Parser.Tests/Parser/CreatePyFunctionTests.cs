using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreatePyFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE FUNCTION mydataset.multiplyInputs(x FLOAT64, y FLOAT64)\nRETURNS FLOAT64\nLANGUAGE python\nOPTIONS(entry_point='multiply', runtime_version='python-3.11' packages=['pandas==2.2'])\nAS r\"\"\"\nimport pandas as pd\n\ndef multiply(df: pd.DataFrame):\n  return df['x'] * df['y']\n\n\"\"\"")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_py_function());
    }
}