using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterOrganizationTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER ORGANIZATION\nSET OPTIONS (\n  `region-us.default_time_zone` = \"America/Chicago\",\n  `region-us.default_job_query_timeout_ms` = 3600000\n)")]
    [InlineData("ALTER ORGANIZATION\nSET OPTIONS (\n  `region-us.default_time_zone` = NULL,\n  `region-us.default_kms_key_name` = NULL,\n  `region-us.default_query_job_timeout_ms` = NULL,\n  `region-us.default_interactive_query_queue_timeout_ms` = NULL,\n  `region-us.default_batch_query_queue_timeout_ms` = NULL)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_organization());
    }
}