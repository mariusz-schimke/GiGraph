using System.Drawing;
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
        /// <para>
        ///     Gets or sets the label in HTML format to display next to the edge.
        /// </para>
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
        /// <para>
        ///     Sets the style of the edge (default: null). See the descriptions of individual <see cref="DotStyle"/> values
        ///     to learn which styles are applicable to this element type.
        /// </para>
        /// <para>
        ///     Multiple styles can be used at once, for example:
        ///     <code>
        ///         <see cref="Style"/> = <see cref="DotStyle.Solid"/> | <see cref="DotStyle.Bold"/>;
        ///     </code>
        /// </para>
        /// </summary>
        DotStyle? Style { get; set; }
        
        /// <summary>
        /// Gets or sets the color used for text (default: <see cref="System.Drawing.Color.Black"/>).
        /// </summary>
        Color? FontColor { get; set; }
        
        /// <summary>
        /// <para>
        ///     Gets or sets the font used for text (default: "Times-Roman"). This very much depends on the output format and,
        ///     for non-bitmap output such as PostScript or SVG, the availability of the font when the graph is displayed or printed.
        ///     As such, it is best to rely on font faces that are generally available, such as Times-Roman, Helvetica or Courier.
        /// </para>
        /// <para>
        ///     How font names are resolved also depends on the underlying library that handles font name resolution.
        ///     If Graphviz was built using the fontconfig library, the latter library will be used to search for the font.
        ///     See the commands fc-list, fc-match and the other fontconfig commands for how names are resolved and which fonts are available.
        ///     Other systems may provide their own font package, such as Quartz for OS X.
        /// </para>
        /// <para>
        ///     Note that various font attributes, such as weight and slant, can be built into the font name.
        ///     Unfortunately, the syntax varies depending on which font system is dominant.
        ///     Thus, using <see cref="FontName"/> = "times bold italic" will produce a bold, slanted Times font using Pango,
        ///     the usual main font library. Alternatively, <see cref="FontName"/> = "times:italic" will produce a slanted Times font
        ///     from fontconfig, while <see cref="FontName"/> = "times-bold" will resolve to a bold Times using Quartz.
        ///     You will need to ascertain which package is used by your Graphviz system and refer to the relevant documentation.
        /// </para>
        /// <para>
        ///     If Graphviz is not built with a high-level font library, <see cref="FontName"/> will be considered the name
        ///     of a Type 1 or True Type font file. If you specify <see cref="FontName"/> = "schlbk", the tool will look
        ///     for a file named schlbk.ttf or schlbk.pfa or schlbk.pfb in one of the directories specified
        ///     by the <see cref="IDotGraphAttributes.FontPath"/> attribute. The lookup does support various aliases for the common fonts.
        /// </para>
        /// </summary>
        string FontName { get; set; }

        /// <summary>
        /// Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges.
        /// The value has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

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
        /// <para>
        ///     Gets or sets edge type for drawing arrow heads. Default: <see cref="DotArrowDirection.Forward"/> (for directed graphs),
        ///     <see cref="DotArrowDirection.None"/> (for undirected graphs).
        /// </para>
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
        /// if the current property is defined and is the identifier of a cluster containing the real head node,
        /// the edge is clipped to the boundary of the cluster.
        /// </summary>
        string LogicalHeadId { get; set; }

        /// <summary>
        /// Logical tail of an edge. When the <see cref="IDotGraphAttributes.Compound"/> property of the graph is true,
        /// if the current property is defined and is the identifier of a cluster containing the real tail node,
        /// the edge is clipped to the boundary of the cluster.
        /// </summary>
        string LogicalTailId { get; set; }

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