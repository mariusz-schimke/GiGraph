namespace GiGraph.Dot.Output.Text.Escaping.Html
{
    /// <summary>
    ///     Escapes spaces with the &amp;#32; HTML code.
    /// </summary>
    public class DotSpaceHtmlEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value?.Replace(" ", "&#32;");
        }
    }
}