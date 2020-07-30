using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Arrow end definition attribute. Assignable to edges only.
    /// </summary>
    public class DotArrowEndDefinitionAttribute : DotAttribute<DotArrowEndDefinition>
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
        public DotArrowEndDefinitionAttribute(string key, DotArrowEndDefinition value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncoded(options, syntaxRules);
        }
    }
}