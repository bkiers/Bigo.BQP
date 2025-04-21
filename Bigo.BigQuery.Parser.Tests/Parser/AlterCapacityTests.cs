using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterCapacityTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER CAPACITY `admin_project.region-us.my-commitment`\nSET OPTIONS (\n  plan = 'THREE_YEAR')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_capacity());
    }
}