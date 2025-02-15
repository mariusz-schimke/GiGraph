namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes angle brackets (&lt;, &gt;). Use for escaping text of record-shaped node fields.
/// </summary>
public class DotAngleBracketsEscaper : IDotTextEscaper
{
    string? IDotTextEscaper.Escape(string? value) => Escape(value);

    public static string? Escape(string? value) => value?.Replace("<", "\\<").Replace(">", "\\>");
}