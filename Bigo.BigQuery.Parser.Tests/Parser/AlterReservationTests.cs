using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterReservationTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER RESERVATION `admin_project.region-us.my-reservation`\nSET OPTIONS (\n  slot_capacity = 300,\n  autoscale_max_slots = 400)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_reservation());
    }
}