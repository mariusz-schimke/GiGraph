using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Packing
{
    /// <summary>
    ///     Packing mode definition with two supported options: packing with specified granularity (see
    ///     <see cref="DotGranularPackingMode" />) or array packing (see <see cref="DotArrayPackingMode" />).
    /// </summary>
    public abstract class DotPackingModeDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        public static implicit operator DotPackingModeDefinition(DotPackingGranularity? value)
        {
            return value.HasValue ? new DotGranularPackingMode(value.Value) : null;
        }

        public static implicit operator DotPackingModeDefinition(DotArrayPackingOption? value)
        {
            return value.HasValue ? new DotArrayPackingMode(value.Value) : null;
        }

        public static implicit operator DotPackingModeDefinition(int? value)
        {
            return value.HasValue ? new DotArrayPackingMode(value.Value) : null;
        }

        protected internal abstract string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules);
    }
}