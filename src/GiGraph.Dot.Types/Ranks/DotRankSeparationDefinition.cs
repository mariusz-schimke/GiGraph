using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Ranks
{
    /// <summary>
    ///     Rank separation (see <see cref="DotRankSeparation" /> and <see cref="DotRadialRankSeparation" />).
    /// </summary>
    public abstract record DotRankSeparationDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules);
        }

        protected abstract string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

        public static implicit operator DotRankSeparationDefinition(double? value)
        {
            return value.HasValue ? new DotRankSeparation(value.Value) : null;
        }

        public static implicit operator DotRankSeparationDefinition(double[] value)
        {
            return value is not null ? new DotRadialRankSeparation(value) : null;
        }
    }
}