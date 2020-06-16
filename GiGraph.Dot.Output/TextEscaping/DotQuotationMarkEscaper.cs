namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes quotation marks. Use for identifiers and attributes that support escaped text.
    /// </summary>
    public class DotQuotationMarkEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value?.Replace(@"""", @"\""");
        }
    }
}