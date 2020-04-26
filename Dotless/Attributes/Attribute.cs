namespace Dotless.Attributes
{
    public abstract class Attribute<T>
    {
        public T Value { get; set; }

        public Attribute(T value)
        {
            Value = value;
        }
    }
}
