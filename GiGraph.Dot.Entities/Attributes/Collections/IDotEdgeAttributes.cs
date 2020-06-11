using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

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
        /// Gets or sets the color of the edge (default: <see cref="System.Drawing.Color.Black"/>).
        /// If <see cref="DotColorList"/> is used, with no weighted colors in its color collection (<see cref="DotColor"/> items only),
        /// the edge is drawn using parallel splines or lines, one for each color in the list, in the order given.
        /// The head arrow, if any, is drawn using the first color in the list, and the tail arrow, if any, the second color.
        /// This supports the common case of drawing opposing edges, but using parallel splines instead of separately routed multiedges.
        /// If any fraction is used, the colors are drawn in series, with each color being given roughly its specified fraction of the edge.
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        /// Gets or sets the color used to fill the arrow head, assuming it has a filled style.
        /// If <see cref="FillColor"/> is not defined, <see cref="Color"/> is used.
        /// If it is not defined too, the default is used, except when the output format is MIF, which use black by default.
        /// </summary>
        DotColorDefinition FillColor { get; set; }

        /// <summary>
        /// Sets the style of the edge (default: null). See the descriptions of individual <see cref="DotStyle"/> values
        /// to learn which styles are applicable to this element type.
        /// <para>
        ///     Multiple styles can be used at once, for example:
        ///     <code>
        ///         <see cref="Style"/> = <see cref="DotStyle.Solid"/> | <see cref="DotStyle.Bold"/>;
        ///     </code>
        /// </para>
        /// </summary>
        DotStyle? Style { get; set; }

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

        /// <summary>
        /// Logical head of an edge. When the <see cref="IDotGraphAttributes.Compound"/> property of the graph is true,
        /// if the current property is defined and is the identifier of a cluster containing the real head, the edge is clipped
        /// to the boundary of the cluster.
        /// </summary>
        string LogicalHead { get; set; }

        /// <summary>
        /// Logical tail of an edge. When the <see cref="IDotGraphAttributes.Compound"/> property of the graph is true,
        /// if the current property is defined and is the identifier of a cluster containing the real tail, the edge is clipped
        /// to the boundary of the cluster.
        /// </summary>
        string LogicalTail { get; set; }

        /// <summary>
        /// If true, attaches edge label to edge by a 2-segment polyline, underlining the label,
        /// then going to the closest point of spline. Default: false.
        /// </summary>
        bool? Decorate { get; set; }

        /// <summary>
        /// If false, the edge is not used in ranking the nodes. Default: true.
        /// <see href="http://www.graphviz.org/doc/info/attrs.html#a:constraint"/>
        /// </summary>
        bool? Constraint { get; set; }
    }
}