namespace Dotless.Attributes
{
    public class DotHtmlLabel : DotLabel
    {
        public DotHtmlLabel(string value)
            : base(value)
        {
        }

        protected override string? QuoteValue(string? value)
        {
            return $@"<{value}>";
        }

        public static implicit operator DotHtmlLabel(string value)
        {
            return new DotHtmlLabel(value);
        }
    }
}
