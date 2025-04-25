using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class RevokeStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("REVOKE `roles/bigquery.admin` ON SCHEMA `myProject`.myDataset\nFROM \"group:example-team@example-pet-store.com\", \"serviceAccount:user@test-project.iam.gserviceaccount.com\"\n")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.revoke_statement());
    }
}