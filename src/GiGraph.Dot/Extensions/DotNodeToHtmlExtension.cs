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
        ///     to learn what HTML grammar is supported.
        /// </summary>
        /// <param name="node">
        ///     The node to convert.
        /// </param>
        /// <param name="html">
        ///     The HTML text to assign to node label. Pass <see cref="string" /> to convert it implicitly to the required
        ///     <see cref="DotHtmlString" /> type.
        /// </param>
        public static void ToHtmlNode(this DotNode node, DotHtmlString html)
        {
            node.Attributes.Shape = DotNodeShape.Plain;
            node.Attributes.Label = html;
        }

        /// <summary>
        ///     Converts the current node to an HTML node by assigning HTML to its label attribute, and setting its shape to
        ///     <see cref="DotNodeShape.Plain" />. See the
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
        ///         documentation
        ///     </see>
        ///     to learn what HTML grammar is supported.
        /// </summary>
        /// <param name="node">
        ///     The node to convert.
        /// </param>
        /// <param name="html">
        ///     The HTML entity to assign to node label.
        /// </param>
        public static void ToHtmlNode(this DotNode node, IDotHtmlEntity html)
        {
            node.Attributes.Shape = DotNodeShape.Plain;
            node.Attributes.Label = new DotHtmlLabel(html);
        }
    }
}