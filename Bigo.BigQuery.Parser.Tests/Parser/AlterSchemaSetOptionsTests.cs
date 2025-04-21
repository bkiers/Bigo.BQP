using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterSchemaSetOptionsTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER SCHEMA mydataset\nSET OPTIONS(\n  default_table_expiration_days=3.75\n  )")]
    [InlineData("ALTER SCHEMA mydataset\nSET OPTIONS(\n  is_case_insensitive=TRUE\n)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_schema_set_options());
    }
}