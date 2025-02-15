namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes the carriage return + line feed character sequence (CRLF == \x000D\x000A == \r\n).
/// </summary>
public class DotWindowsNewLineEscaper : IDotTextEscaper
{
    string? IDotTextEscaper.Escape(string? value) => Escape(value);

    public static string? Escape(string? value) => value?.Replace(DotNewLine.Windows, "\\n");
}