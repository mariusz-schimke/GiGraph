namespace Dotless.Attributes
{
    public abstract class Attribute<T> : IAttribute<T>
    {
        public virtual string Key { get; }
        public virtual T Value { get; }

        object? IAttribute.Value => Value!;

        public Attribute(string key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}
