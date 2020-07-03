using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides helper methods for <see cref="DotNode" />.
    /// </summary>
    public static class DotNodeToHtmlExtension
    {
        /// <summary>
        ///     Converts the current node to a HTML-like node by assigning it an HTML label. See the
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#html">
        ///         documentation
        ///     </see>
        ///     to learn what HTML grammar is supported.
        /// </summary>
        /// <param name="node">
        ///     The node whose HTML label to set.
        /// </param>
        /// <param name="html">
        ///     The HTML to assign to the label.
        /// </param>
        public static void ToHtml(this DotNode node, string html)
        {
            node.Attributes.Shape = DotNodeShape.Plain;
            node.Attributes.Label = (DotLabelHtml) html;
        }
    }
}