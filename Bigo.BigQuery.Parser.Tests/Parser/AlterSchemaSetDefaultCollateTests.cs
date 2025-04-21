using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterSchemaSetDefaultCollateTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER SCHEMA mydataset\nSET DEFAULT COLLATE 'und:ci'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_schema_set_default_collate());
    }
}