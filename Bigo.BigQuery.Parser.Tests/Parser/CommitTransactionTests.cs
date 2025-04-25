using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CommitTransactionTests : BaseParserTest
{
    [Theory]
    [InlineData("COMMIT")]
    [InlineData("commit tranasction")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.commit_transaction());
    }
}