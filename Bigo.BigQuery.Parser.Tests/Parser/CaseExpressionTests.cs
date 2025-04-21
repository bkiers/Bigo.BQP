using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CaseExpressionTests : BaseParserTest
{
    [Theory]
    [InlineData("CASE A\n    WHEN 90 THEN 'red'\n    WHEN 50 THEN 'blue'\n    ELSE 'green'\n    END")]
    [InlineData("CASE A\n    WHEN 90 THEN 'red'\n    WHEN 50 THEN 'blue'\n    END")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.case_expression());
    }
}