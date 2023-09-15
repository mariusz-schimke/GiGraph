namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes the environment new line character or sequence (system-dependent).
/// </summary>
public class DotSystemDefaultNewLineEscaper : IDotTextEscaper
{
    string IDotTextEscaper.Escape(string value) => Escape(value);

    public static string Escape(string value) => value?.Replace(DotNewLine.SystemDefault, "\\n");
}