using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Arrowhead definition attribute. Assignable to edges only.
    /// </summary>
    public class DotArrowheadDefinitionAttribute : DotAttribute<DotArrowheadDefinition>
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
        public DotArrowheadDefinitionAttribute(string key, DotArrowheadDefinition value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncoded(options, syntaxRules);
        }
    }
}