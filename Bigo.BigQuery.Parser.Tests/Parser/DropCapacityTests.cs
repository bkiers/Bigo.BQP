using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropCapacityTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP CAPACITY `admin_project.region-us.1234`")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_capacity());
    }
}