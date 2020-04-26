namespace Dotless.Attributes
{
    public class HtmlLabel : Label
    {
        public HtmlLabel(string value)
            : base(value)
        {
        }

        public static implicit operator HtmlLabel(string value)
        {
            return new HtmlLabel(value);
        }
    }
}
