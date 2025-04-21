using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class CreateVectorIndexTests : BaseParserTest
{
    [Theory]
    [InlineData("CREATE VECTOR INDEX my_index ON my_dataset.my_table(embedding)\nOPTIONS (index_type = 'IVF')")]
    [InlineData("CREATE VECTOR INDEX my_index ON my_dataset.my_table(embedding)\nOPTIONS (\n  index_type = 'IVF',\n  distance_type = 'COSINE',\n  ivf_options = '{\"num_lists\":2500}')")]
    [InlineData("CREATE VECTOR INDEX my_index ON my_dataset.my_table(embedding)\nOPTIONS (\n  index_type = 'TREE_AH',\n  distance_type = 'EUCLIDEAN',\n  tree_ah_options = '{\"normalization_type\": \"L2\"}')")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.create_vector_index());
    }
}