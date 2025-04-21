using Antlr4.Runtime;
using BigO.BigQuery.Parser;
using Shouldly;

namespace Bigo.BigQuery.Parser.Tests.Lexer;

public abstract class BaseLexerTest
{
    protected static IList<IToken> Tokenize(string input, bool removeEof = true)
    {
        return Tokenize(input, [Antlr4.Runtime.Lexer.DefaultTokenChannel], removeEof);
    }

    protected static void SingleToken(string input, int expectedTokenType, int channel = Antlr4.Runtime.Lexer.DefaultTokenChannel)
    {
        var token = SingleToken(input, [channel]);

        var errorMessage = $"Expected a {BigQueryLexer.DefaultVocabulary.GetSymbolicName(expectedTokenType)} token " +
                           $"but got a {BigQueryLexer.DefaultVocabulary.GetSymbolicName(token.Type)}";

        token.Type.ShouldBe(expectedTokenType, errorMessage);
        token.Channel.ShouldBe(channel);
    }

    private static IList<IToken> Tokenize(string input, int[] channels, bool removeEof = true)
    {
        var lexer = new BigQueryLexer(CharStreams.fromString(input));
        var stream = new CommonTokenStream(lexer);

        stream.Fill();

        var tokens = stream.GetTokens();

        if (removeEof)
        {
            tokens.RemoveAt(tokens.Count - 1);
        }

        return tokens.Where(t => channels.Contains(t.Channel)).ToList();
    }

    private static IToken SingleToken(string input, int[]? channels = null, bool removeEof = true)
    {
        var tokens = Tokenize(input, channels ?? [Antlr4.Runtime.Lexer.DefaultTokenChannel], removeEof);

        tokens.Count.ShouldBe(1, input);

        return tokens.Single();
    }
}