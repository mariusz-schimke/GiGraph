using System.Web;

namespace GiGraph.Dot.Output.TextEscaping.Escapers.Html
{
    /// <summary>
    ///     Converts a string to an HTML-encoded string.
    /// </summary>
    public class DotHtmlEncodeEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value is not null ? HttpUtility.HtmlEncode(value) : null;
        }
    }
}