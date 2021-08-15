using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Types.Html;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides extension methods for <see cref="DotNode" />.
    /// </summary>
    public static class DotNodeToHtmlExtension
    {
        /// <summary>
        ///     Converts the current node to an HTML node by assigning HTML text to its label attribute, and setting its shape to
        ///     <see cref="DotNodeShape.Plain" />. See the
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
        ///         documentation
        ///     </see>
        ///     to learn what HTML grammar is supported. Useful when the HTML entity represents a table and you don't want the node to have
        ///     any shape.
        /// </summary>
        /// <param name="node">
        ///     The node to convert.
        /// </param>
        /// <param name="html">
        ///     The HTML text to assign to node label.
        /// </param>
        public static void ToPlainHtmlNode(this DotNode node, string html)
        {
            node.ToPlainHtmlNode((DotHtmlLabel) (DotHtmlString) html);
        }

        /// <summary>
        ///     Converts the current node to an HTML node by assigning HTML to its label attribute, and setting its shape to
        ///     <see cref="DotNodeShape.Plain" />. Useful when the HTML entity represents a table and you don't want the node to have any
        ///     shape.
        /// </summary>
        /// <param name="node">
        ///     The node to convert.
        /// </param>
        /// <param name="html">
        ///     The HTML entity to assign to node label.
        /// </param>
        public static void ToPlainHtmlNode(this DotNode node, IDotHtmlEntity html)
        {
            node.ToPlainHtmlNode(new DotHtmlLabel(html));
        }

        private static void ToPlainHtmlNode(this DotNode node, DotHtmlLabel label)
        {
            node.Shape = DotNodeShape.Plain;
            node.Label = label;
        }
    }
}