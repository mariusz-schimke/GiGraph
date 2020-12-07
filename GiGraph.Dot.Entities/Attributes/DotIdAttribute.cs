using GiGraph.Dot.Entities.Types.Identifiers;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents the identifier of an element.
    /// </summary>
    public class DotIdAttribute : DotAttribute<DotId>
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="id">
        ///     The identifier of the element.
        /// </param>
        public DotIdAttribute(string key, DotId id)
            : base(key, id)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}