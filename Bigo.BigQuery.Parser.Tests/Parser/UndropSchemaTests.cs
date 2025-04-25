using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class UndropSchemaTests : BaseParserTest
{
    [Theory]
    [InlineData("UNDROP SCHEMA mydataset")]
    [InlineData("UNDROP SCHEMA IF NOT EXISTS project.mydataset")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.undrop_schema());
    }
}