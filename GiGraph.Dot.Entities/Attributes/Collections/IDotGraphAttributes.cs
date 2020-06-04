using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;

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
        /// </summary>
        Color? BackgroundColor { get; set; }

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