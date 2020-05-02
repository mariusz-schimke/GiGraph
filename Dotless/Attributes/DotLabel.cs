namespace Dotless.Attributes
{
    public abstract class DotLabel : DotAttribute<string>
    {
        public static readonly string AttributeKey = "label";

        public DotLabel(string value)
            : base(AttributeKey, value)
        {
        }

        public static implicit operator DotLabel(string value)
        {
            return new DotTextLabel(value);
        }

        public static implicit operator string(DotLabel label)
        {
            return label._value;
        }
    }
}
