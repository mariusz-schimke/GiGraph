using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Colors;

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
        /// Gets or sets the background color of the graph (default: none).
        /// Used as the background for entire canvas.
        /// <para>
        /// For certain output formats, such as PostScript, no fill is done for the root graph unless background color is explicitly set.
        /// For bitmap formats, however, the bits need to be initialized to something, so the canvas is filled with white by default.
        /// This means that if the bitmap output is included in some other document, all of the bits within the bitmap's bounding box will be set,
        /// overwriting whatever color or graphics were already on the page. If this effect is not desired,
        /// and you only want to set bits explicitly assigned in drawing the graph, set <see cref="BackgroundColor"/> = <see cref="Color.Transparent"/>.
        /// </para>
        /// </summary>
        Color? BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background color list of the cluster.
        /// Used as the background for entire canvas.
        /// If the value specifies multiple colors, a gradient fill is used. By default, this is a linear fill;
        /// setting <see cref="Style"/> to <see cref="DotStyle.Radial"/> will cause a radial fill.
        /// At present, only two colors are used. If the second color is missing, the default color is used for it.
        /// See also the <see cref="GradientAngle"/> attribute for setting the gradient angle.
        /// <para>
        /// For certain output formats, such as PostScript, no fill is done for the root graph unless background color is explicitly set.
        /// For bitmap formats, however, the bits need to be initialized to something, so the canvas is filled with white by default.
        /// This means that if the bitmap output is included in some other document, all of the bits within the bitmap's bounding box will be set,
        /// overwriting whatever color or graphics were already on the page. If this effect is not desired,
        /// and you only want to set bits explicitly assigned in drawing the graph, set <see cref="BackgroundColor"/> = <see cref="Color.Transparent"/>.
        /// </para>
        /// </summary>
        DotWeightedColor[] BackgroundColorList { get; set; }

        /// <summary>
        /// If a gradient fill is being used, this determines the angle of the fill. 
        /// For linear fills, the colors transform along a line specified by the angle and the center of the object.
        /// For radial fills, a value of zero causes the colors to transform radially from the center;
        /// for non-zero values, the colors transform from a point near the object's periphery as specified by the value.
        /// If unset, the default angle is 0.
        /// </summary>
        int? GradientAngle { get; set; }

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