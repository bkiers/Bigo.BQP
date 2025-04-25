using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class BeginTransactionTests : BaseParserTest
{
    [Theory]
    [InlineData("BEGIN")]
    [InlineData("begin TRANSACTION")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.begin_transaction());
    }
}