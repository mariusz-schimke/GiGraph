using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Writers.TokenWriter;

public class DotAppendTokenEventArgs(string? token, DotTokenType tokenType, bool linger) : EventArgs
{
    public string? Token { get; } = token;
    public DotTokenType TokenType { get; } = tokenType;
    public bool Linger { get; } = linger;

    public bool IsCommentStartToken => TokenType is DotTokenType.CommentStart
        or DotTokenType.DiscardedLineStart
        or DotTokenType.BlockCommentStart;
}