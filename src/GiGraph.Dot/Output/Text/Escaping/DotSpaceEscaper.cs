namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes spaces.
/// </summary>
public class DotSpaceEscaper : IDotTextEscaper
{
    string? IDotTextEscaper.Escape(string? value) => Escape(value);

    public static string? Escape(string? value) => value?.Replace(" ", "\\ ");
}