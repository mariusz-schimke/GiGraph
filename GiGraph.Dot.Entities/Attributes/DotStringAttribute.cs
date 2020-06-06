using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// String attribute. The text provided as a value will be escaped on DOT script generation so that is is interpreted correctly
    /// by graph visualization tools. If you want the value to be rendered as is, use <see cref="DotCustomAttribute"/> instead.
    /// </summary>
    public class DotStringAttribute : DotCommonAttribute<string>
    {
        protected readonly TextEscapingPipeline _valueEscaper;

        protected DotStringAttribute(string key, string value, TextEscapingPipeline valueEscaper)
            : base(key, value)
        {
            _valueEscaper = valueEscaper ?? TextEscapingPipeline.ForString();
        }

        /// <summary>
        /// Creates a new instance of a string attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute. The text will be escaped on graph generation, 
        /// so when the graph is visualized, it will be displayed exactly the way it is provided here.</param>
        public DotStringAttribute(string key, string value)
            : this(key, value, valueEscaper: null)
        {
        }

        protected override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return _valueEscaper.Escape(Value);
        }
    }
}