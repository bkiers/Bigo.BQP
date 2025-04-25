using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropAssignmentTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP ASSIGNMENT `admin_project.region-us.prod.1234`")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_assignment());
    }
}