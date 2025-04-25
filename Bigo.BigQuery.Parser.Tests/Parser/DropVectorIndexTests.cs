using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropVectorIndexTests : BaseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_vector_index());
    }
}