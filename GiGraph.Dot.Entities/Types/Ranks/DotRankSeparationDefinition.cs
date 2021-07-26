using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Ranks
{
    /// <summary>
    ///     Rank separation (see <see cref="DotRankSeparation" /> and <see cref="DotRadialRankSeparation" />).
    /// </summary>
    public abstract class DotRankSeparationDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules);
        }

        protected internal abstract string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

        public static implicit operator DotRankSeparationDefinition(double? value)
        {
            return value.HasValue ? new DotRankSeparation(value.Value) : null;
        }

        public static implicit operator DotRankSeparationDefinition(double[] value)
        {
            return value is { } ? new DotRadialRankSeparation(value) : null;
        }
    }
}