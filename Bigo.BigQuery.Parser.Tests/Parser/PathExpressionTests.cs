using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class PathExpressionTests : BaseParserTest
{
    [Theory]
    [InlineData("_5abc")]
    [InlineData("dataField")]
    [InlineData("`5abc`.dataField")]
    [InlineData("abc5")]
    [InlineData("`GROUP`.`5abc`")]
    [InlineData("abc5.GROUP")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.path_expression());
    }
}