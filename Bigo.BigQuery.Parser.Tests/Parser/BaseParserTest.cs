using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using BigO.BigQuery.Parser;
using Bigo.BigQuery.Parser.Tests.Lexer;
using Xunit;

namespace Bigo.BigQuery.Parser.Tests.Parser;

public abstract class BaseParserTest : BaseLexerTest
{
    protected static (BigQueryLexer, BigQueryParser) CreateLexerAndParser(string input)
    {
        var lexer = new BigQueryLexer(CharStreams.fromString(input));
        var parser = new BigQueryParser(new CommonTokenStream(lexer))
        {
            ErrorHandler = new BailErrorStrategy()
        };

        return (lexer, parser);
    }

    protected static void ParseAllTokens(string input, Func<BigQueryParser, IParseTree> func)
    {
        try
        {
            var (lexer, parser) = CreateLexerAndParser(input);
            var tree = func(parser);

            List<IToken> remainingTokens = [];

            while (true)
            {
                var nextToken = lexer.NextToken();

                if (nextToken.Type == BigQueryLexer.Eof)
                {
                    break;
                }

                if (nextToken.Channel != Antlr4.Runtime.Lexer.Hidden)
                {
                    remainingTokens.Add(nextToken);
                }
            }

            if (remainingTokens.Count == 0)
            {
                return;
            }

            var remainingTokenValues = remainingTokens.Select(t => $"({BigQueryLexer.DefaultVocabulary.GetSymbolicName(t.Type)}: '{t.Text}')");

            Assert.Fail($"Only `{tree.GetText()}` from `{input}` was parsed, remaining tokens: [{string.Join(", ", remainingTokenValues)}]");
        }
        catch
        {
            var token = BaseLexerTest.Tokenize(input);
            var allTokens = token.Select(t => $"({BigQueryLexer.DefaultVocabulary.GetSymbolicName(t.Type)}: '{t.Text}')");

            Assert.Fail($"Could not parse: {input}\nAll tokens:\n{string.Join("\n", allTokens)}");
        }
    }
}