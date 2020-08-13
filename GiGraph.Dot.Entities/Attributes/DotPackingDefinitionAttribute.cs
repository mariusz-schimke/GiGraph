using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Determines whether packing is enabled (see <see cref="DotPackingToggle" />) or specifies a margin around each laid out
    ///     component (see <see cref="DotPackingMargin" />).
    /// </summary>
    public class DotPackingDefinitionAttribute : DotAttribute<DotPackingDefinition>
    {
        /// <summary>
        ///     Creates a new packing definition attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotPackingDefinitionAttribute(string key, DotPackingDefinition value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}