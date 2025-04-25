using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class LoopTests : BaseParserTest
{
    [Theory]
    [InlineData("loop select 1; end loop")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.loop());
    }
}