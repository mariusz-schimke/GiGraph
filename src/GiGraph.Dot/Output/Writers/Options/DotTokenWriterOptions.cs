﻿using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Writers.Options;

public record DotTokenWriterOptions(
    int IndentationLevel,
    int IndentationSize,
    char IndentationChar,
    string LineBreak,
    bool SingleLine,
    bool HashForSingleLineComments,
    Func<string?, DotTokenType, string?>? TextEncoder
)
{
    public virtual DotTokenWriterOptions ToSingleLine() =>
        this with
        {
            SingleLine = true
        };

    public virtual DotTokenWriterOptions IncreaseIndentation() =>
        this with
        {
            IndentationLevel = IndentationLevel + 1
        };
}