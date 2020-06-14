using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// A label attribute. The value can either be a string (<see cref="DotLabelString"/>) or an HTML string (<see cref="DotLabelHtml"/>).
    /// </summary>
    public class DotLabelStringAttribute : DotAttribute<DotLabelString>
    {
        /// <summary>
        /// Creates a new instance of a string attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotLabelStringAttribute(string key, DotLabelString value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return Value?.GetDotEncodedString(options);
        }
    }
}