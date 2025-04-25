using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropSchemaTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP SCHEMA mydataset")]
    [InlineData("DROP SCHEMA IF EXISTS mydataset CASCADE")]
    [InlineData("DROP SCHEMA mydataset RESTRICT")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_schema());
    }
}