namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Escapes spaces with the &#32; HTML code.
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