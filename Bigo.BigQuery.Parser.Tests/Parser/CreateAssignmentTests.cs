using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateAssignmentTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE ASSIGNMENT `admin_project.region-us.prod.my_assignment`\nOPTIONS (\n  assignee = 'projects/my_project',\n  job_type = 'QUERY')")]
    [InlineData("CREATE ASSIGNMENT `admin_project.region-us.prod.my_assignment`\nOPTIONS (\n  assignee = 'organizations/1234',\n  job_type = 'PIPELINE')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_assignment());
    }
}