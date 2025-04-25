using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class BeginExceptionEndTests : BaseParserTest
{
    [Theory]
    [InlineData("BEGIN\n  DECLARE y INT64;\n  SET y = x;\n  SELECT y;\nEXCEPTION WHEN ERROR THEN\n    SELECT 1/0; END")]
    [InlineData("BEGIN\n  CALL schema1.proc2();\nEXCEPTION WHEN ERROR THEN\n  SELECT\n    @@error.message,\n    @@error.stack_trace,\n    @@error.statement_text,\n    @@error.formatted_stack_trace;\nEND")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.begin_exception_end());
    }
}