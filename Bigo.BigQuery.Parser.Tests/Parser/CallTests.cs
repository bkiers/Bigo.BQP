using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CallTests : BaseParserTest
{
    [Theory]
    [InlineData("CALL mySchema.UpdateSomeTables('someAccountId', retCode)")]
    [InlineData("CALL mySchema.UpdateSomeTables()")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.call());
    }
}