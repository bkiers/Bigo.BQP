
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class WindowFrameClauseTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.window_frame_clause());
    }
}
    