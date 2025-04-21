using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class AlterTableSetOptionsTests : BaseParserTest
{
    [Theory]
    [InlineData("ALTER TABLE mydataset.mytable\nSET OPTIONS (\n  expiration_timestamp=TIMESTAMP_ADD(CURRENT_TIMESTAMP(), INTERVAL 7 DAY),\n  description=\"Table that expires seven days from now\"\n)")]
    [InlineData("ALTER TABLE mydataset.mypartitionedtable\nSET OPTIONS (require_partition_filter=true)")]
    [InlineData("ALTER TABLE mydataset.mytable\nSET OPTIONS (expiration_timestamp=NULL)")]
    [InlineData("ALTER TABLE if exists mydataset.mytable\nSET OPTIONS (expiration_timestamp=NULL)")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.alter_table_set_options());
    }
}