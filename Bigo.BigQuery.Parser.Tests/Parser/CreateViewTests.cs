using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateViewTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE VIEW mydataset.age_groups(age, count) AS SELECT age")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_view());
    }
}