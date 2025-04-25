using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CaseSearchExpressionTests : BaseParserTest
{
    [Theory]
    [InlineData("CASE product_id\n  WHEN 1 THEN\n    SELECT CONCAT('Product one');\nEND CASE")]
    [InlineData("CASE product_id\n  WHEN 1 THEN\n    SELECT CONCAT('Product one');\n  WHEN 2 THEN\n    SELECT CONCAT('Product two');\nEND CASE")]
    [InlineData("CASE product_id\n  WHEN 1 THEN\n    SELECT CONCAT('Product one');\n  WHEN 2 THEN\n    SELECT CONCAT('Product two');\n  ELSE\n    SELECT CONCAT('Invalid product');\nEND CASE")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.case_search_expression());
    }
}