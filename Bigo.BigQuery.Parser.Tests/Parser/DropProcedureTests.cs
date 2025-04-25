using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DropProcedureTests : BaseParserTest
{
    [Theory]
    [InlineData("DROP PROCEDURE sample_dataset.myprocedure")]
    [InlineData("DROP PROCEDURE IF EXISTS `other-project`.sample_dataset.myprocedure")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.drop_procedure());
    }
}