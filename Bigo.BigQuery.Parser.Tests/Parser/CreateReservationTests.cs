using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateReservationTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE RESERVATION `admin_project.region-us.prod`\nOPTIONS (\n  slot_capacity = 100)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_reservation());
    }
}