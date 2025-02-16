using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Writers.TokenWriter;

public class DotAppendTokenEventArgs : EventArgs
{
    public DotAppendTokenEventArgs(string? token, DotTokenType tokenType, bool linger)
    {
        Token = token;
        TokenType = tokenType;
        Linger = linger;
    }

    public string? Token { get; }
    public DotTokenType TokenType { get; }
    public bool Linger { get; }

    public bool IsCommentStartToken => TokenType is DotTokenType.CommentStart
        or DotTokenType.DiscardedLineStart
        or DotTokenType.BlockCommentStart;
}