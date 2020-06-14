using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// A string attribute whose value is escaped on DOT script rendering when <see cref="DotEscapableString"/> is used,
    /// or is assumed to already be escaped when <see cref="DotEscapedString"/> is used.
    /// </summary>
    public class DotEscapeStringAttribute : DotAttribute<DotEscapableString>
    {
        /// <summary>
        /// Creates a new instance of a string attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotEscapeStringAttribute(string key, DotEscapableString value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return Value?.GetDotEncodedString(options);
        }
    }
}