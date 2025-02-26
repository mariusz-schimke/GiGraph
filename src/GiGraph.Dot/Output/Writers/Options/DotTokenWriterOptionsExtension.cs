using GiGraph.Dot.Output.Text;

namespace GiGraph.Dot.Output.Writers.Options;

public static class DotTokenWriterOptionsExtension
{
    public static string Indentation(this DotTokenWriterOptions options) =>
        options.SingleLine
            ? string.Empty
            : string.Empty.PadRight(options.IndentationSize * options.IndentationLevel, options.IndentationChar);

    public static string Alignment(this DotTokenWriterOptions options, int width) =>
        options.SingleLine
            ? string.Empty
            : options.Space(width);

    public static string Space(this DotTokenWriterOptions options) => options.Space(1);

    public static string Space(this DotTokenWriterOptions options, int count) => string.Empty.PadRight(count);

    public static string LineBreak(this DotTokenWriterOptions options) =>
        options.SingleLine
            ? options.Space()
            : options.LineBreak;

    public static string[] SplitMultilineText(this DotTokenWriterOptions options, string? text) =>
        text is null
            ? []
            : text.Split([DotNewLine.Windows, DotNewLine.Unix], StringSplitOptions.None);
}