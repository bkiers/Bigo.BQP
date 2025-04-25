using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterModelTests : BaseParserTest
{
    [Theory]
    [InlineData("alter model model_name set options (a = b, c = 33)")]
    [InlineData("alter model if exists model_name set options (a = b, c = 33)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_model());
    }
}