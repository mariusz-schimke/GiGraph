using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Packing
{
    /// <summary>
    ///     Determines whether packing is enabled (see <see cref="DotPackingState" />) or specifies a margin around each laid out
    ///     component (see <see cref="DotPackingMargin" />).
    /// </summary>
    public abstract class DotPackingDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        public static implicit operator DotPackingDefinition(int? value)
        {
            return value.HasValue ? new DotPackingMargin(value.Value) : null;
        }

        public static implicit operator DotPackingDefinition(bool? value)
        {
            return value.HasValue ? new DotPackingState(value.Value) : null;
        }

        protected internal abstract string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules);
    }
}