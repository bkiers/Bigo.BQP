using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public class DeleteStatementTests : BaseParserTest
{
    [Theory]
    [InlineData("DELETE dataset.Inventory WHERE quantity = 0")]
    [InlineData("DELETE FROM dataset.Inventory iii WHERE iii.quantity = 0")]
    [InlineData("DELETE dataset.Inventory i\nWHERE i.product NOT IN (SELECT product from dataset.NewArrivals)\n")]
    [InlineData("DELETE dataset.Inventory\nWHERE NOT EXISTS\n  (SELECT * from dataset.NewArrivals\n   WHERE Inventory.product = NewArrivals.product)\n")]
    public void Test(string input)
    {
        ParseAllTokens(input, parser => parser.delete_statement());
    }
}