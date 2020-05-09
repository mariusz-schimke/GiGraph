namespace Gigraph.Dot.Entities.Attributes
{
    public class DotHtmlLabelAttribute : DotLabelAttribute
    {
        public DotHtmlLabelAttribute(string value)
            : base(value)
        {
        }

        public static implicit operator DotHtmlLabelAttribute(string value)
        {
            return value is { } ? new DotHtmlLabelAttribute(value) : null;
        }
    }
}
