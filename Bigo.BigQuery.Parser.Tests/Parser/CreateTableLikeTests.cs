using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateTableLikeTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE TABLE mydataset.newtable\nLIKE mydataset.sourcetable")]
    [InlineData("CREATE TABLE mydataset.newtable\nLIKE mydataset.sourcetable\nAS SELECT * FROM mydataset.myothertable")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_table_like());
    }
}