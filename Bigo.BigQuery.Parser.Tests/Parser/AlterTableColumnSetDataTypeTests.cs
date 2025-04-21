using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableColumnSetDataTypeTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE dataset.my_table ALTER COLUMN c1 SET DATA TYPE NUMERIC")]
    [InlineData("ALTER TABLE dataset.my_table ALTER COLUMN s1\nSET DATA TYPE STRUCT <a NUMERIC, b STRING>")]
    [InlineData("ALTER TABLE dataset.my_table\nALTER COLUMN pt\nSET DATA TYPE NUMERIC(8,2)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_column_set_data_type());
    }
}