using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateTableCloneTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE TABLE `myproject.mydataset.mytable`\nCLONE `myproject.mydataset.mytablesnapshot`\nOPTIONS(\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 365 DAY),\n  friendly_name=\"my_table\",\n  description=\"A table that expires in 1 year\",\n  labels=[(\"org_unit\", \"development\")]\n)")]
    [InlineData("CREATE TABLE IF NOT EXISTS `myproject.mydataset.mytableclone`\nCLONE `myproject.mydataset.mytable`\nOPTIONS(\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 365 DAY),\n  friendly_name=\"my_table\",\n  description=\"A table that expires in 1 year\",\n  labels=[(\"org_unit\", \"development\")]\n)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_table_clone());
    }
}