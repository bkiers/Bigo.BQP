using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using BigO.BigQuery.Parser;

const string query = """
                     SELECT
                       cs.customer_id,
                       cs.customer_name,
                       cs.email,
                       cs.country,
                       cs.recent_order_count,
                       cs.recent_order_total,
                       cs.last_order_date,
                       CASE
                         WHEN cs.recent_order_total > 1000 THEN 'High Value'
                         WHEN cs.recent_order_total BETWEEN 500 AND 1000 THEN 'Medium Value'
                         ELSE 'Low Value'
                       END AS customer_segment,
                       COUNT(r.review_id) AS review_count,
                       AVG(r.rating) AS avg_rating,
                       ARRAY_AGG(DISTINCT p.category) AS categories_purchased,
                       MIN(p.price) AS min_product_price,
                       MAX(p.price) AS max_product_price
                     FROM
                       customer_summary cs
                     LEFT JOIN
                       `project.dataset.reviews` r ON cs.customer_id = r.customer_id
                     LEFT JOIN
                       `project.dataset.orders` o ON cs.customer_id = o.customer_id
                     LEFT JOIN
                       UNNEST(o.product_ids) AS product_id
                     LEFT JOIN
                       `project.dataset.products` p ON p.product_id = product_id
                     GROUP BY
                       cs.customer_id, cs.customer_name, cs.email, cs.country,
                       cs.recent_order_count, cs.recent_order_total, cs.last_order_date
                     ORDER BY
                       cs.recent_order_total DESC
                     LIMIT 100
                     """;

var lexer = new BigQueryLexer(CharStreams.fromString(query));
var parser = new BigQueryParser(new CommonTokenStream(lexer));
var listener = new GroupedByListener();

ParseTreeWalker.Default.Walk(listener, parser.statement_eof());

Console.WriteLine($"Grouped by: [{string.Join(", ", listener.Expressions)}]");

internal class GroupedByListener : BigQueryParserBaseListener
{
  public List<string> Expressions { get; } = [];

  public override void EnterGroup_by_specification(BigQueryParser.Group_by_specificationContext context)
  {
    if (context.groupable_items is not null)
    {
      foreach (var expression in context.groupable_items.expression())
      {
        Expressions.Add(expression.GetText());
      }
    }
    else
    {
      Console.WriteLine($"Didn't handle: {context.GetText()}");
    }
  }
}