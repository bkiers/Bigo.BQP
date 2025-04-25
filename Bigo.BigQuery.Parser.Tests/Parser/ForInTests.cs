using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ForInTests : BaseParserTest
{
    [Theory]
    [InlineData("FOR record IN\n  (SELECT word, word_count\n   FROM `bigquery-public-data`.samples.shakespeare\n   LIMIT 5)\nDO\n  SELECT record.word, record.word_count;\nEND FOR")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.for_in());
    }
}