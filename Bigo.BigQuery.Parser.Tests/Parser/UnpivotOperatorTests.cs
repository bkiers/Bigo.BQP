using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class UnpivotOperatorTests : BaseParserTest
{
    [Theory]
    [InlineData("UNPIVOT (sales FOR quarter IN (Q1, Q2, Q3, Q4))")]
    [InlineData("UNPIVOT INCLUDE NULLS (sales FOR quarter IN (Q1, Q2, Q3, Q4))")]
    [InlineData("UNPIVOT EXCLUDE NULLS (sales FOR quarter IN (Q1, Q2, Q3, Q4))")]
    [InlineData("UNPIVOT (sales FOR quarter IN (Q1, Q2, Q3, Q4)) as alias")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.unpivot_operator());
    }
}