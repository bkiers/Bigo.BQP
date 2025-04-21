using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateAggregateFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE AGGREGATE FUNCTION myProject.myDataset.ScaledSum(\n  dividend FLOAT64,\n  divisor FLOAT64 NOT AGGREGATE)\nRETURNS FLOAT64\nAS (\n  SUM(dividend) / divisor\n)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_aggregate_function());
    }
}