namespace Dotless.TextEscaping
{
    public class QuotationMarkEscaper : ITextEscaper
    {
        public virtual string? Escape(string? value)
        {
            return value?.Replace(@"""", @"\""");
        }
    }
}
