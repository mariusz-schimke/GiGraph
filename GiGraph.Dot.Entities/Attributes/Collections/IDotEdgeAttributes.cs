using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEdgeAttributes : IDotAttributeCollection
    {
        /// <summary>
        /// Gets or sets the label to display next to the edge.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the label in HTML format to display next to the edge.
        /// <para>
        ///     <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        ///     so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        string LabelHtml { get; set; }

        /// <summary>
        /// Gets or sets the color of the edge.
        /// </summary>
        Color? Color { get; set; }

        /// <summary>
        /// Gets or sets the style of arrow head on the head node of an edge.
        /// This will only appear if the direction attribute is "forward" or "both". 
        /// </summary>
        DotArrowType? ArrowHead { get; set; }

        /// <summary>
        /// Gets or sets the style of arrow head on the tail node of an edge.
        /// This will only appear if the direction attribute is "back" or "both".
        /// </summary>
        DotArrowType? ArrowTail { get; set; }
    }
}
