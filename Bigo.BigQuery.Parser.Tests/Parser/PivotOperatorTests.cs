using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class PivotOperatorTests : BaseParserTest
{
    [Theory]
    [InlineData("PIVOT(SUM(sales) FOR quarter IN ('Q1', 'Q2', 'Q3', 'Q4'))")]
    [InlineData("PIVOT(SUM(sales) FOR quarter IN ('Q1', 'Q2', 'Q3', 'Q4')) as something")]
    [InlineData("PIVOT(SUM(sales) AS total_sales, COUNT(*) AS num_records FOR quarter IN ('Q1', 'Q2'))")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.pivot_operator());
    }
}