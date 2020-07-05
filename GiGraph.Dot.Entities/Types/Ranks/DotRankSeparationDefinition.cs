using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Ranks
{
    /// <summary>
    ///     Rank separation (see <see cref="DotRankSeparation" /> and <see cref="DotRankSeparationList" />).
    /// </summary>
    public abstract class DotRankSeparationDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules);
        }

        protected internal abstract string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules);

        public static implicit operator DotRankSeparationDefinition(double? value)
        {
            return (DotRankSeparation) value;
        }

        public static implicit operator DotRankSeparationDefinition(double[] value)
        {
            return (DotRankSeparationList) value;
        }
    }
}