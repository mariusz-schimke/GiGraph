namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes spaces ( ) with a &#32; HTML code. Use for escaping text of record node fields.
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