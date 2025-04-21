using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableColumnSetOptionsTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\nALTER COLUMN price\nSET OPTIONS (description = 'Price per unit')")]
    [InlineData("ALTER VIEW mydataset.myview\nALTER COLUMN total\nSET OPTIONS (description = 'Total sales of the product')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_column_set_options());
    }
}