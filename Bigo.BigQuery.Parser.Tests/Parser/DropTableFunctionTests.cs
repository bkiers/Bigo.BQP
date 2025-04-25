using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropTableFunctionTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP TABLE FUNCTION mydataset.my_table_function")]
    [InlineData("DROP TABLE FUNCTION IF EXISTS mydataset.my_table_function")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_table_function());
    }
}