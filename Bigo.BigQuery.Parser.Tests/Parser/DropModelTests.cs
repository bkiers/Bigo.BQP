using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropModelTests : BaseParserTest
{
    [Theory]
    [InlineData("drop model foo")]
    [InlineData("drop model if exists `foo & bar`")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_model());
    }
}