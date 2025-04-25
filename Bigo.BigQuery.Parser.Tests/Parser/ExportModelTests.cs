using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class ExportModelTests : BaseParserTest
{
    // EXPORT MODEL MODEL_NAME [OPTIONS ( URI = STRING_VALUE )]
    [Theory]
    [InlineData("export model model_name")]
    [InlineData("export model model_name options (uri = 'gs://bucket/path/to/file.csv')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.export_model());
    }
}