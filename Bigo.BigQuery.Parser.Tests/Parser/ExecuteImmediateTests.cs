using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ExecuteImmediateTests : BaseParserTest
{
    [Theory]
    [InlineData("EXECUTE IMMEDIATE \"SELECT ? * (? + 2)\" INTO y USING 1, 3")]
    [InlineData("EXECUTE IMMEDIATE expression(\"SELECT ? * (? + 2)\") INTO y USING 1, 3")]
    [InlineData("EXECUTE IMMEDIATE \"SELECT @a * (@b + 2)\" INTO y USING 1 as a, 3 as b")]
    [InlineData("EXECUTE IMMEDIATE\n  \"CREATE TEMP TABLE Books (title STRING, publish_date INT64)\"")]
    [InlineData("EXECUTE IMMEDIATE\n  \"INSERT INTO Books (title, publish_date) VALUES(?, ?)\"\n  USING book_name, book_year")]
    [InlineData("EXECUTE IMMEDIATE\n  \"INSERT INTO Books (title, publish_date) VALUES(@name, @year)\"\n  USING 1815 as year, \"Emma\" as name")]
    [InlineData("EXECUTE IMMEDIATE\n  CONCAT(\n    \"INSERT INTO Books (title, publish_date)\", \"VALUES('Middlemarch', 1871)\"\n  )")]
    [InlineData("EXECUTE IMMEDIATE \"SELECT MIN(publish_date) FROM Books LIMIT 1\" INTO first_date")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.execute_immediate());
    }
}