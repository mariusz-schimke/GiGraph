using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute<T> : DotAttribute
    {
        protected DotAttribute(string key, T value)
            : base(key)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the attribute.
        /// </summary>
        public virtual T Value { get; }

        /// <summary>
        /// Converts the value to string using the default converter (unless overriden in a descendant class).
        /// </summary>
        public override string ToString()
        {
            return Value?.ToString();
        }

        protected internal override object GetValue()
        {
            return Value;
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.ToString() ?? string.Empty;
        }

        public static implicit operator T(DotAttribute<T> attribute)
        {
            return attribute is { } ? attribute.Value : default;
        }
    }
}