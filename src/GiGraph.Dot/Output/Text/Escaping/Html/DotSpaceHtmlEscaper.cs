namespace GiGraph.Dot.Output.Text.Escaping.Html;

/// <summary>
///     Escapes spaces with the &amp;#32; HTML code.
/// </summary>
public class DotSpaceHtmlEscaper : IDotTextEscaper
{
    string IDotTextEscaper.Escape(string value) => Escape(value);

    public static string Escape(string value) => value?.Replace(" ", "&#32;");
}