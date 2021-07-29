using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing
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
        /// <param name="size">
        ///     The size, in
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#points">
        ///         points
        ///     </see>
        ///     , of a margin around each graph part being packed.
        /// </param>
        public DotPackingMargin(int size)
        {
            Size = size;
        }

        /// <summary>
        ///     Gets or sets the size, in
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#points">
        ///         points
        ///     </see>
        ///     , of a margin around each graph part being packed.
        /// </summary>
        public virtual int Size { get; set; }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Size.ToString();
        }
    }
}