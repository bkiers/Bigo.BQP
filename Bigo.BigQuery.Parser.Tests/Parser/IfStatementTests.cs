using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class IfStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("IF EXISTS(SELECT 1 FROM schema.products\n           WHERE product_id = target_product_id) THEN\n  SELECT CONCAT('found product ', CAST(target_product_id AS STRING));\n  ELSEIF EXISTS(SELECT 1 FROM schema.more_products\n           WHERE product_id = target_product_id) THEN\n  SELECT CONCAT('found product from more_products table',\n  CAST(target_product_id AS STRING));\nELSE\n  SELECT CONCAT('did not find product ', CAST(target_product_id AS STRING));\nEND IF")]
    [InlineData("if true then end if")]
    [InlineData("if true then select 1; end if")]
    [InlineData("if false then select 1; elseif true then select 2; end if")]
    [InlineData("if false then select 1; else select 2; end if")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.if_statement());
    }
}