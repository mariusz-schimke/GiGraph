using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// String attribute.
    /// </summary>
    public class DotStringAttribute : DotAttribute<DotString>
    {
        /// <summary>
        /// Creates a new instance of a string attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotStringAttribute(string key, string value)
            : base(key, value)
        {
        }

        /// <summary>
        /// Creates a new instance of a string attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotStringAttribute(string key, DotString value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return Value?.GetDotEncodedValue(options);
        }
    }
}