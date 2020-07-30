using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Arrowhead shape attribute. Assignable to edges only. See the
    ///     <see href="https://www.graphviz.org/doc/info/arrows.html">
    ///         documentation
    ///     </see>
    ///     to view how individual shapes are visualized.
    /// </summary>
    public class DotArrowheadShapeAttribute : DotAttribute<DotArrowheadShape>
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
        public DotArrowheadShapeAttribute(string key, DotArrowheadShape value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return new DotArrowhead(Value).GetDotEncoded(options, syntaxRules);
        }
    }
}