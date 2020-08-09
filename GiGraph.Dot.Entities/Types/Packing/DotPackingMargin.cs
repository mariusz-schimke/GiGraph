using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Packing
{
    /// <summary>
    ///     Used as the size, in
    ///     <see href="http://www.graphviz.org/doc/info/attrs.html#points">
    ///         points
    ///     </see>
    ///     , of a margin around each graph part being packed.
    /// </summary>
    public class DotPackingMargin : DotPackingDefinition
    {
        /// <summary>
        ///     Creates a new instance initialized with margin size.
        /// </summary>
        /// <param name="value">
        ///     The size of the margin.
        /// </param>
        public DotPackingMargin(int value)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets or sets the size of the margin.
        /// </summary>
        public virtual int Value { get; set; }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value.ToString();
        }
    }
}