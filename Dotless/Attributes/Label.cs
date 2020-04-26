namespace Dotless.Attributes
{
    public abstract class Label : Attribute<string>
    {
        public Label(string value)
            : base(value)
        {
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
