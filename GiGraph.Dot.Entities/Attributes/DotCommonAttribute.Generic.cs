using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotCommonAttribute<T> : DotCommonAttribute
    {
        /// <summary>
        /// Gets or sets the value of the attribute.
        /// </summary>
        public virtual T Value { get; }

        public DotCommonAttribute(string key, T value)
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
        /// <param name="options">The DOT generation options to use.</param>
        protected override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return Value?.ToString() ?? string.Empty;
        }

        public static implicit operator T(DotCommonAttribute<T> attribute)
        {
            return attribute is { } ? attribute.Value : default;
        }
    }
}