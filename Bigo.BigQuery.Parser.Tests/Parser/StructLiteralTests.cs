using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class StructLiteralTests : BaseParserTest
{
    [Theory]
    [InlineData("(1, 2, 3)")]
    [InlineData("(1, 'abc')")]
    [InlineData("STRUCT<INT64, STRING>(1, 'abc')")]
    [InlineData("STRUCT(1)")]
    [InlineData("STRUCT<INT64>(1)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.struct_literal());
    }
}