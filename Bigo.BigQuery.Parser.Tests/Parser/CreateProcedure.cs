using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateProcedure : BaseParserTest
{
    [Theory]
    [InlineData("CREATE PROCEDURE myProject.myDataset.QueryTable()\nBEGIN\n  SELECT * FROM anotherDataset.myTable;\nEND")]
    [InlineData("CREATE PROCEDURE mydataset.AddDelta(INOUT x INT64, delta INT64)\nBEGIN\n  SET x = x + delta;\nEND")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_procedure());
    }
}