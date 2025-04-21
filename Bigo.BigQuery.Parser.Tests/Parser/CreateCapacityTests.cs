using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateCapacityTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE CAPACITY `admin_project.region-us.my-commitment`\nOPTIONS (\n  slot_count = 100,\n  plan = 'ANNUAL')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_capacity());
    }
}