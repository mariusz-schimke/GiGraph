using System.Web;

namespace GiGraph.Dot.Output.Text.Escaping.Html;

/// <summary>
///     Converts a string to an HTML-encoded string.
/// </summary>
public class DotHtmlEncodeEscaper : IDotTextEscaper
{
    string? IDotTextEscaper.Escape(string? value) => Escape(value);

    public static string? Escape(string? value) => HttpUtility.HtmlEncode(value!);
}