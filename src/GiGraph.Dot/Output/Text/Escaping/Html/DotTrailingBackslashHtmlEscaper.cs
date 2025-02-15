namespace GiGraph.Dot.Output.Text.Escaping.Html;

/// <summary>
///     Escapes trailing backslash with the &amp;#92; HTML code.
/// </summary>
public class DotTrailingBackslashHtmlEscaper : IDotTextEscaper
{
    string? IDotTextEscaper.Escape(string? value) => Escape(value);

    public static string? Escape(string? value) =>
        true == value?.EndsWith("\\")
            ? $"{value.Remove(value.Length - 1)}&#92;"
            : value;
}