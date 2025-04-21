using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class WindowFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("LAST_VALUE(book)\n  OVER (ORDER BY year)")]
    [InlineData("LAST_VALUE(book)\n  OVER (\n    ORDER BY year\n    RANGE BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)")]
    [InlineData("LAST_VALUE(item)\n  OVER (item_window ROWS BETWEEN 2 PRECEDING AND 2 FOLLOWING)")]
    [InlineData("SUM(purchases)\n  OVER ()")]
    [InlineData("SUM(purchases)\n  OVER (\n    PARTITION BY category\n    ORDER BY purchases\n    ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING\n  )")]
    [InlineData("SUM(purchases)\n  OVER (\n    PARTITION BY category\n    ORDER BY purchases\n    ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW\n  )")]
    [InlineData("SUM(purchases)\n  OVER (\n    PARTITION BY category\n    ORDER BY purchases\n    ROWS UNBOUNDED PRECEDING\n  )")]
    [InlineData("SUM(purchases)\n  OVER (\n    ORDER BY purchases\n    ROWS BETWEEN UNBOUNDED PRECEDING AND 2 PRECEDING\n  )")]
    [InlineData("AVG(purchases)\n  OVER (\n    ORDER BY purchases\n    ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING\n  )")]
    [InlineData("COUNT(*)\n  OVER (\n    ORDER BY population\n    RANGE BETWEEN 1 PRECEDING AND 1 FOLLOWING\n  )")]
    [InlineData("LAST_VALUE(item)\n  OVER (\n    PARTITION BY category\n    ORDER BY purchases\n    ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING\n  )")]
    [InlineData("LAST_VALUE(item)\n  OVER (\n    PARTITION BY category\n    ORDER BY purchases\n    ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING\n  )")]
    [InlineData("LAST_VALUE(item)\n  OVER (\n    item_window\n    ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING\n  )")]
    [InlineData("RANK() OVER (PARTITION BY department ORDER BY start_date)")]
    [InlineData("LAST_VALUE(item)\n  OVER (item_window)")]
    [InlineData("LAST_VALUE(item)\n  OVER (\n    item_window\n    ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING\n    )")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.window_function());
    }
}