namespace Gigraph.Dot.Entities.Attributes
{
    public abstract class DotLabelAttribute : DotAttribute<string>
    {
        public static string AttributeKey => "label";

        public DotLabelAttribute(string value)
            : base(AttributeKey, value)
        {
        }

        public static implicit operator DotLabelAttribute(string value)
        {
            return value is { } ? new DotTextLabelAttribute(value) : null;
        }
    }
}
