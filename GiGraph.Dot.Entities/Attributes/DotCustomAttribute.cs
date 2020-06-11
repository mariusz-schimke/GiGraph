using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// An attribute with any key and any value that are directly supported by a destination DOT graph renderer.
    /// The value specified for the attribute will be rendered as is in the output script (without escaping)
    /// or escaped using a custom value escaping pipeline if provided.
    /// </summary>
    public class DotCustomAttribute : DotAttribute<string>
    {
        protected readonly IDotTextEscaper _valueEscaper;

        /// <summary>
        /// Creates a new custom attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute in a format understood by a destination DOT graph renderer.
        /// The value will be rendered as is in the output script (without escaping).</param>
        public DotCustomAttribute(string key, string value)
            : this(key, value, valueEscaper: null)
        {
        }

        /// <summary>
        /// Creates a new custom attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute in a format understood by a destination DOT graph visualization tool.</param>
        /// <param name="valueEscaper">The text escaping pipeline to use for the value when generating a DOT script.</param>
        public DotCustomAttribute(string key, string value, IDotTextEscaper valueEscaper)
            : base(key, value)
        {
            _valueEscaper = valueEscaper ?? TextEscapingPipeline.None();
        }

        protected override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return _valueEscaper.Escape(Value);
        }
    }
}