using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class BeginEndTests : BaseParserTest
{
    [Theory]
    [InlineData("BEGIN\n  DECLARE y INT64;\n  SET y = x;\n  SELECT y;\nEND")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.begin_end());
    }
}