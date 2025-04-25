using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropReservationTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP RESERVATION `admin_project.region-us.prod`")]
    [InlineData("DROP RESERVATION IF EXISTS `admin_project.region-us.prod`")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_reservation());
    }
}