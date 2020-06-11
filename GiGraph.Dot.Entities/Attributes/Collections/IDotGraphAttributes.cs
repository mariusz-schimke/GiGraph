using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotGraphAttributes : IDotAttributeCollection
    {
        /// <summary>
        /// Gets or sets the label to display on the graph.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the label in HTML format to display on the graph.
        /// <para>
        ///     <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        ///     so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        string LabelHtml { get; set; }

        /// <summary>
        /// Gets or sets the color to use for clusters (default: <see cref="System.Drawing.Color.Black"/>).
        /// If <see cref="DotColorList"/> is used, with no weighted colors in its color collection (<see cref="DotColor"/> items only),
        /// and the <see cref="Style"/> is <see cref="DotStyle.Filled"/>, a linear gradient fill is done using the first two colors.
        /// If weighted colors are present (see <see cref="DotWeightedColor"/>), a degenerate linear gradient fill is done.
        /// This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight"/> specifying how much of region is filled with each color.
        /// If the <see cref="Style"/> attribute contains the value <see cref="DotStyle.Radial"/>, then a radial gradient fill is done.
        /// These fills work with any shape. For certain shapes, the <see cref="Style"/> attribute can be set to do fills using more than 2 colors
        /// (see <see cref="DotStyle.Striped"/>).
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        /// Gets or sets the background color of the graph (default: none).
        /// Used as the background for entire canvas.
        /// <para>
        /// When <see cref="DotColorList"/> is used, a gradient fill is generated. By default, this is a linear fill;
        /// setting <see cref="Style"/> to <see cref="DotStyle.Radial"/> will cause a radial fill.
        /// At present, only two colors are used. If the second color is <see cref="System.Drawing.Color.Empty"/>,
        /// the default color is used for it. See also the <see cref="GradientAngle"/> attribute for setting the gradient angle.
        /// </para>
        /// <para>
        /// For certain output formats, such as PostScript, no fill is done for the root graph unless background color is explicitly set.
        /// For bitmap formats, however, the bits need to be initialized to something, so the canvas is filled with white by default.
        /// This means that if the bitmap output is included in some other document, all of the bits within the bitmap's bounding box will be set,
        /// overwriting whatever color or graphics were already on the page. If this effect is not desired,
        /// and you only want to set bits explicitly assigned in drawing the graph, set <see cref="BackgroundColor"/> = <see cref="System.Drawing.Color.Transparent"/>.
        /// </para>
        /// </summary>
        DotColorDefinition BackgroundColor { get; set; }

        /// <summary>
        /// If a gradient fill is being used, this determines the angle of the fill. 
        /// For linear fills, the colors transform along a line specified by the angle and the center of the object.
        /// For radial fills, a value of zero causes the colors to transform radially from the center;
        /// for non-zero values, the colors transform from a point near the object's periphery as specified by the value.
        /// If unset, the default angle is 0.
        /// </summary>
        int? GradientAngle { get; set; }

        /// <summary>
        /// Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges and clusters.
        /// The value is inherited by subclusters. It has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        /// Color used to draw the bounding box around clusters (default: <see cref="System.Drawing.Color.Black"/>).
        /// If <see cref="PenColor"/> is not defined, <see cref="Color"/> is used. If this is not defined, the default is used.
        /// Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a pen color,
        /// this will override a <see cref="IDotClusterAttributes.Color"/> or <see cref="IDotClusterAttributes.BackgroundColor"/>
        /// attribute set for the cluster.
        /// </summary>
        Color? PenColor { get; set; }

        /// <summary>
        /// Gets or sets the direction of graph layout (default: <see cref="DotRankDirection.TopToBottom"/>).
        /// </summary>
        DotRankDirection? LayoutDirection { get; set; }

        /// <summary>
        /// Sets the style of the graph (default: null). See the descriptions of individual <see cref="DotStyle"/> values
        /// to learn which styles are applicable to this element type.
        /// <para>
        ///     Multiple styles can be used at once, for example:
        ///     <code>
        ///         <see cref="Style"/> = <see cref="DotStyle.Rounded"/> | <see cref="DotStyle.Bold"/>;
        ///     </code>
        /// </para>
        /// </summary>
        DotStyle? Style { get; set; }

        /// <summary>
        /// If true, edge concentrators are used. This merges multiedges into a single edge, and causes partially parallel edges
        /// to share part of their paths. The latter feature is not yet available outside of DOT.
        /// </summary>
        bool? ConcentrateEdges { get; set; }

        /// <summary>
        /// If true, allows edges between clusters. Default: false;
        /// See also the <see cref="IDotEdgeAttributes.LogicalHead"/> and <see cref="IDotEdgeAttributes.LogicalTail"/>
        /// attributes of the edge.
        /// </summary>
        bool? Compound { get; set; }
    }
}