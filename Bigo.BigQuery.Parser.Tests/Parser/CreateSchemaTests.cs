using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateSchemaTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE SCHEMA mydataset OPTIONS(location=\"us\", default_table_expiration_days=3.75, labels=[(\"label1\",\"value1\"),(\"label2\",\"value2\")])")]
    [InlineData("CREATE SCHEMA mydataset OPTIONS(is_case_insensitive=TRUE)")]
    [InlineData("CREATE SCHEMA mydataset DEFAULT COLLATE 'und:ci'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_schema());
    }
}