using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP FUNCTION mydataset.parseJsonAsStruct")]
    [InlineData("DROP FUNCTION `other_project`.sample_dataset.parseJsonAsStruct")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_function());
    }
}