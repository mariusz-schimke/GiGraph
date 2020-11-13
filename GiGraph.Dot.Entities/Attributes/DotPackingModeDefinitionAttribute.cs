using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Packing mode definition with two supported options: packing with specified granularity (see
    ///     <see cref="DotGranularPackingMode" />) or array packing (see <see cref="DotArrayPackingMode" />).
    /// </summary>
    public class DotPackingModeDefinitionAttribute : DotAttribute<DotPackingModeDefinition>
    {
        /// <summary>
        ///     Creates a new packing mode definition attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotPackingModeDefinitionAttribute(string key, DotPackingModeDefinition value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}