using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Nodes;
using GiGraph.Dot.Entities.Types.Text;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides extension methods for <see cref="DotNode" />.
    /// </summary>
    public static class DotNodeToHtmlExtension
    {
        /// <summary>
        ///     Converts the current node to an HTML-like node by assigning HTML text to its label attribute, and setting its shape to
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
        ///     <see cref="DotHtml" /> type.
        /// </param>
        public static void ToHtmlNode(this DotNode node, DotHtml html)
        {
            node.Attributes.Shape = DotNodeShape.Plain;
            node.Attributes.Label = html;
        }
    }
}