using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class RollbackTransactionTests : BaseParserTest
{
    [Theory]
    [InlineData("ROLLBACK")]
    [InlineData("rollback transaction")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.rollback_transaction());
    }
}