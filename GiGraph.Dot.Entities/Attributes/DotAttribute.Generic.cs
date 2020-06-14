using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    public abstract class DotAttribute<T> : DotAttribute
    {
        /// <summary>
        /// Gets or sets the value of the attribute.
        /// </summary>
        public virtual T Value { get; }

        protected DotAttribute(string key, T value)
            : base(key)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key), "Attribute key cannot be null.");
            }

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
        protected internal override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return Value?.ToString() ?? string.Empty;
        }

        public static implicit operator T(DotAttribute<T> attribute)
        {
            return attribute is { } ? attribute.Value : default;
        }
    }
}