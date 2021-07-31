namespace GiGraph.Dot.Output.TextEscaping.Escapers
{
    /// <summary>
    ///     Escapes quotation marks.
    /// </summary>
    public class DotQuotationMarkEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value?.Replace("\"", "\\\"");
        }
    }
}