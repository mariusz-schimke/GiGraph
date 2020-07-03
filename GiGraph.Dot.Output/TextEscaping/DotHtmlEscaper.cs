using System.Web;

namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Converts a string to an HTML-encoded string. Use for identifiers and attributes that support escaped text when your
    ///     visualization tool has issues processing national and special characters.
    /// </summary>
    public class DotHtmlEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value is { } ? HttpUtility.HtmlEncode(value) : value;
        }
    }
}