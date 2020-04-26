namespace Dotless.Attributes
{
    public abstract class Label : Attribute<string>
    {
        public static readonly string AttributeKey = "label";

        public Label(string value)
            : base(AttributeKey, value)
        {
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator Label(string value)
        {
            return new TextLabel(value);
        }

        public static implicit operator string(Label label)
        {
            return label.Value;
        }
    }
}
