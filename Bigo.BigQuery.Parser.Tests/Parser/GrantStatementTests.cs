using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class GrantStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("GRANT `roles/bigquery.dataViewer` ON SCHEMA `myProject`.myDataset\nTO \"user:raha@example-pet-store.com\", \"user:sasha@example-pet-store.com\"\n")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.grant_statement());
    }
}