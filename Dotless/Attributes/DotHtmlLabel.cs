namespace Dotless.Attributes
{
    public class DotHtmlLabel : DotLabel
    {
        public DotHtmlLabel(string? value)
            : base(value)
        {
        }

        public static implicit operator DotHtmlLabel(string value)
        {
            return new DotHtmlLabel(value);
        }
    }
}
