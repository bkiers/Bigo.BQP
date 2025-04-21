using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateRemoteFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE TEMP FUNCTION tempRemoteMultiplyInputs(x FLOAT64, y FLOAT64)\nRETURNS FLOAT64\nREMOTE WITH CONNECTION us.myconnection\nOPTIONS(endpoint=\"https://us-central1-myproject.cloudfunctions.net/multiply\")")]
    [InlineData("CREATE FUNCTION mydataset.remoteMultiplyInputs(x FLOAT64, y FLOAT64)\nRETURNS FLOAT64\nREMOTE WITH CONNECTION us.myconnection\nOPTIONS(endpoint=\"https://us-central1-myproject.cloudfunctions.net/multiply\")")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_remote_function());
    }
}