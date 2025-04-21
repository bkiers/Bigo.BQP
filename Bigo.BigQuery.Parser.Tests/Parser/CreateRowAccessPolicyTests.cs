using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateRowAccessPolicyTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE ROW ACCESS POLICY policy_name\nON dataset.table_name\nGRANT TO (\"user@example.com\", \"group:analysts@example.com\")\nFILTER USING (expression)")]
    [InlineData("CREATE ROW ACCESS POLICY only_see_own_data\nON my_dataset.sales\nGRANT TO (\"user1@example.com\", \"user2@example.com\")\nFILTER USING (sales_rep = SESSION_USER())")]
    [InlineData("CREATE ROW ACCESS POLICY regional_access\nON my_dataset.orders\nGRANT TO (\"group:europe_sales@example.com\")\nFILTER USING (region = \"EU\")")]
    [InlineData("CREATE ROW ACCESS POLICY owner_or_public\nON my_dataset.documents\nGRANT TO (\"allAuthenticatedUsers\")\nFILTER USING (\n  visibility = \"public\" OR owner = SESSION_USER()\n)")]
    [InlineData("CREATE ROW ACCESS POLICY role_based_access\nON my_dataset.hr_records\nGRANT TO (\"role:hr_analyst\", \"role:manager\")\nFILTER USING (department = \"HR\")")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_row_access_policy());
    }
}