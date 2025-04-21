using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateExternalSchemaTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE EXTERNAL SCHEMA mydataset\nWITH CONNECTION myproject.`aws-us-east-1`.myconnection\n  OPTIONS (\n    external_source = 'aws-glue://arn:aws:glue:us-east-1:123456789:database/test_database',\n    location = 'aws-us-east-1')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_external_schema());
    }
}