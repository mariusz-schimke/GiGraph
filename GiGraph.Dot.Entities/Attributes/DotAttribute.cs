namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute : IDotAttribute
    {
        public string Key { get; set; }

        protected abstract string GetDotEncodedValue();

        protected DotAttribute(string key)
        {
            Key = key;
        }

        string IDotAttribute.GetDotEncodedValue() => GetDotEncodedValue();
    }

    public abstract class DotAttribute<T> : DotAttribute, IDotAttribute
    {
        protected T Value { get; set; }

        public DotAttribute(string key, T value)
            : base(key)
        {
            Value = value;
        }

        /// <summary>
        /// Converts the value to string using the default converter (unless overriden in a descendant class).
        /// </summary>
        public override string ToString()
        {
            return Value?.ToString();
        }

        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        protected override string GetDotEncodedValue()
        {
            return Value?.ToString() ?? string.Empty;
        }

        public static implicit operator T(DotAttribute<T> attribute)
        {
            return attribute is { } ? attribute.Value : default;
        }
    }
}
