namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes backslashes.
/// </summary>
public class DotBackslashEscaper : IDotTextEscaper
{
    string? IDotTextEscaper.Escape(string? value) => Escape(value);

    public static string? Escape(string? value) => value?.Replace("\\", @"\\");
}