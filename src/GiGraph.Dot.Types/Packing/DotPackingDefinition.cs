using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing
{
    /// <summary>
    ///     Determines whether packing is enabled (see <see cref="DotPackingToggle" />) or specifies a margin around each laid out
    ///     component (see <see cref="DotPackingMargin" />).
    /// </summary>
    public abstract record DotPackingDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        public static implicit operator DotPackingDefinition(int? value)
        {
            return value.HasValue ? new DotPackingMargin(value.Value) : null;
        }

        public static implicit operator DotPackingDefinition(bool? value)
        {
            return value.HasValue ? new DotPackingToggle(value.Value) : null;
        }

        protected abstract string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
    }
}