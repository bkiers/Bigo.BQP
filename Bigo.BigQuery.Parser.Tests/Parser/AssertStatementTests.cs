using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AssertStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("ASSERT (\n  (SELECT COUNT(*) > 5 FROM UNNEST([1, 2, 3, 4, 5, 6]))\n) AS 'Table must contain more than 5 rows.'")]
    [InlineData("ASSERT (\n  (SELECT COUNT(*) > 10 FROM UNNEST([1, 2, 3, 4, 5, 6]))\n) AS 'Table must contain more than 10 rows.'")]
    [InlineData("ASSERT\n  EXISTS(\n    (SELECT X FROM UNNEST([7877, 7879, 7883, 7901, 7907]) AS X WHERE X = 7907))\nAS 'Column X must contain the value 7907.'")]
    [InlineData("ASSERT\n  EXISTS(\n    (SELECT X FROM UNNEST([7877, 7879, 7883, 7901, 7907]) AS X WHERE X = 7919))\nAS 'Column X must contain the value 7919'")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.assert_statement());
    }
}