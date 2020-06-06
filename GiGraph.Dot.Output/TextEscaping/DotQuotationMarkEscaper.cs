namespace GiGraph.Dot.Generators.TextEscaping
{
    public class DotQuotationMarkEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value?.Replace(@"""", @"\""");
        }
    }
}
