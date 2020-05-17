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
        /// Gets or sets the color of the edge (default: <see cref="Color.Black"/>).
        /// </summary>
        Color? Color { get; set; }

        /// <summary>
        /// Gets or sets the multiplicative scale factor for arrowheads (default: 1.0, minimum: 0.0).
        /// </summary>
        double? ArrowSize { get; set; }

        /// <summary>
        /// Gets or sets the style of arrow head on the head node of an edge (default: <see cref="DotArrowType.Normal"/>).
        /// Appears only if the <see cref="ArrowDirection"/> attribute is <see cref="DotArrowDirection.Forward"/> or 
        /// <see cref="DotArrowDirection.Both"/>.
        /// </summary>
        DotArrowType? ArrowHead { get; set; }

        /// <summary>
        /// Gets or sets the style of arrow head on the tail node of an edge (default: <see cref="DotArrowType.Normal"/>).
        /// Appears only if the <see cref="ArrowDirection"/> attribute is <see cref="DotArrowDirection.Backward"/> or 
        /// <see cref="DotArrowDirection.Both"/>.
        /// </summary>
        DotArrowType? ArrowTail { get; set; }

        /// <summary>
        /// Gets or sets edge type for drawing arrow heads. Default: <see cref="DotArrowDirection.Forward"/> (for directed graphs),
        /// <see cref="DotArrowDirection.None"/> (for undirected graphs).
        /// <para>
        ///     Indicates which ends of the edge should be decorated with an arrow head.
        ///     The actual style of the arrow head can be specified using the <see cref="ArrowHead"/> and <see cref="ArrowTail"/> attributes.
        /// </para>
        /// <para>
        ///     A glyph is drawn at the head end of an edge if and only if the arrow direction is 
        ///     <see cref="DotArrowDirection.Forward"/> or <see cref="DotArrowDirection.Both"/>.
        /// </para>    
        /// <para>
        ///     A glyph is drawn at the tail end of an edge if and only if the direction is 
        ///     <see cref="DotArrowDirection.Backward"/> or <see cref="DotArrowDirection.Both"/>.
        /// </para>    
        /// <para>
        ///     For undirected edges T -- H, one of the nodes, usually the right hand one, is treated as the head
        ///     for the purpose of interpreting <see cref="DotArrowDirection.Forward"/> and <see cref="DotArrowDirection.Backward"/>.
        /// </para>
        /// </summary>
        DotArrowDirection? ArrowDirection { get; set; }
    }
}
