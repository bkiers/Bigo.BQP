using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterBiCapacityTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER BI_CAPACITY `my-project.region-us.default`\nSET OPTIONS(\n  size_gb = 250\n)")]
    [InlineData("ALTER BI_CAPACITY `my-project.region-us.default`\nSET OPTIONS(\n  size_gb = 0\n)")]
    [InlineData("ALTER BI_CAPACITY `my-project.region-us.default`\nSET OPTIONS(\n  preferred_tables = NULL\n)")]
    [InlineData("ALTER BI_CAPACITY `my-project.region-us.default`\nSET OPTIONS(\n  size_gb = 250,\n  preferred_tables = [\"data_project1.dataset1.table1\",\n                      \"data_project2.dataset2.table2\"]\n)")]
    [InlineData("ALTER BI_CAPACITY `region-us.default`\nSET OPTIONS(\n  preferred_tables = [\"dataset1.table1\",\n                      \"data_project2.dataset2.table2\"]\n)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_bi_capacity());
    }
}