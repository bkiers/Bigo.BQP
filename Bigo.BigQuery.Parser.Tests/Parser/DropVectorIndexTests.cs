using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropVectorIndexTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP VECTOR INDEX my_index ON my_table")]
    [InlineData("DROP VECTOR INDEX IF EXISTS my_index ON dataset.my_table")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_vector_index());
    }
}