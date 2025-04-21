
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterMaterializedViewTests : BaseParserTest
{
    // [Theory]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    // [InlineData("")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_materialized_view());
    }
}