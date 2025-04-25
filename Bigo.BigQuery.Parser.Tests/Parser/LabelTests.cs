using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class LabelTests : BaseParserTest
{
    [Theory]
    [InlineData("label_1: BEGIN\n  SELECT 1;\n  BREAK label_1;\n  SELECT 2; -- Unreached\nEND")]
    [InlineData("label_1: LOOP\n  BREAK label_1;\nEND LOOP label_1")]
    [InlineData("label_2: BEGIN\n  BREAK label_2;\nEND")]
    [InlineData("label_1: BEGIN\n   DECLARE label_1 INT64;\n   BREAK label_1;\nEND")]
    [InlineData("label_1: BEGIN\n  BREAK label_1;\nEND label_1")]
    [InlineData("label_1: BEGIN\n  BREAK label_1;\nEND")]
    [InlineData("label_1: LOOP\n  WHILE x < 1 DO\n    IF y < 1 THEN\n      CONTINUE label_1;\n    ELSE\n      BREAK label_1; END IF; \n  END WHILE;\nEND LOOP label_1")]
    [InlineData("label_1: BEGIN\n  SELECT 1;\n  EXCEPTION WHEN ERROR THEN\n    BREAK label_1;\n    SELECT 2; -- Unreached\nEND")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.label());
    }
}