using GiGraph.Dot.Entities.Types.ArrowShapes;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Arrow type attribute. Assignable to edges only.
    ///     <see href="https://www.graphviz.org/doc/info/attrs.html#k:arrowType">
    ///         View how individual arrow types are visualized
    ///     </see>
    ///     .
    /// </summary>
    public class DotArrowDefinitionAttribute : DotAttribute<DotArrowDefinition>
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
        public DotArrowDefinitionAttribute(string key, DotArrowDefinition value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncoded(options, syntaxRules);
        }
    }
}