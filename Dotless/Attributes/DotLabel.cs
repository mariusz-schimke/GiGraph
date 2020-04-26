namespace Dotless.Attributes
{
    public abstract class DotLabel : DotTextualAttribute
    {
        public DotLabel(string value)
            : base(key: "label", value)
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
