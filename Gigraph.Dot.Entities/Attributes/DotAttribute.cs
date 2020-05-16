namespace Gigraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute : IDotAttribute
    {
        protected readonly string _key;

        protected abstract string GetValueAsString();

        string IDotAttribute.Key => _key;
        string IDotAttribute.Value => GetValueAsString();

        protected DotAttribute(string key)
        {
            _key = key;
        }
    }

    public abstract class DotAttribute<T> : DotAttribute, IDotAttribute
    {
        protected readonly T _value;

        protected DotAttribute(string key, T value)
            : base(key)
        {
            _value = value;
        }

        /// <summary>
        /// Converts the value to string using the default converter (unless overriden in a descendant class).
        /// </summary>
        public override string ToString()
        {
            return _value?.ToString();
        }

        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        protected override string GetValueAsString()
        {
            return _value?.ToString() ?? string.Empty;
        }

        public static implicit operator T(DotAttribute<T> value)
        {
            return value is { } ? value._value : default;
        }
    }
}
