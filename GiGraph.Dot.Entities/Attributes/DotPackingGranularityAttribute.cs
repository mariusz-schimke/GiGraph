using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Packing granularity attribute.
    /// </summary>
    public class DotPackingGranularityAttribute : DotAttribute<DotPackingGranularity>
    {
        /// <summary>
        ///     Creates a new packing granularity attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotPackingGranularityAttribute(string key, DotPackingGranularity value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return new DotGranularPackingMode(Value).GetDotEncodedValue(options, syntaxRules);
        }
    }
}