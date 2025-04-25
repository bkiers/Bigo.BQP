using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DeclareTests : BaseParserTest
{
    [Theory]
    [InlineData("DECLARE x INT64")]
    [InlineData("DECLARE d DATE DEFAULT CURRENT_DATE()")]
    [InlineData("DECLARE x, y, z INT64 DEFAULT 0")]
    [InlineData("DECLARE item DEFAULT (SELECT item FROM schema1.products LIMIT 1)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.declare());
    }
}