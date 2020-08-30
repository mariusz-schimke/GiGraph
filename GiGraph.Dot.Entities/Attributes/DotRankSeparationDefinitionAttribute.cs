using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     In dot, this attribute gives the desired rank separation, in inches (<see cref="DotRankSeparation" />). In twopi, this
    ///     attribute specifies the radial separation of concentric circles (<see cref="DotRadialRankSeparation" />).
    /// </summary>
    public class DotRankSeparationDefinitionAttribute : DotAttribute<DotRankSeparationDefinition>
    {
        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotRankSeparationDefinitionAttribute(string key, DotRankSeparationDefinition value)
            : base(key, value)
        {
        }

        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotRankSeparationDefinitionAttribute(string key, DotRankSeparation value)
            : base(key, value)
        {
        }

        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotRankSeparationDefinitionAttribute(string key, DotRadialRankSeparation value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncoded(options, syntaxRules);
        }
    }
}