using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Labels;

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
        ///     The HTML text to assign to node label.
        /// </param>
        public static void SetHtml(this DotNode node, string html)
        {
            node.Attributes.Shape = DotNodeShape.Plain;
            node.Attributes.Label = (DotHtmlLabel) html;
        }
    }
}