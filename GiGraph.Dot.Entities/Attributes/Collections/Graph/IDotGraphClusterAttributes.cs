using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphClusterAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the color to use for clusters (default: <see cref="System.Drawing.Color.Black" />).
        ///     </para>
        ///     <para>
        ///         If <see cref="DotGradientColor" /> is used, with no weighted colors in its parameters (<see cref="DotColor" /> items
        ///         only), and the style attribute of the graph (<see cref="DotGraphAttributes.Style" />) or of individual clusters (
        ///         <see cref="DotClusterAttributes.Style" />) contains <see cref="DotStyles.Filled" />, a linear gradient fill is done.
        ///     </para>
        ///     <para>
        ///         If <see cref="DotGradientColor" /> is used with weighted colors (see <see cref="DotWeightedColor" />), a degenerate
        ///         linear gradient fill is done. This essentially does a fill using two colors, with the
        ///         <see cref="DotWeightedColor.Weight" /> specifying how much of region is filled with each color.
        ///     </para>
        ///     <para>
        ///         If the style attribute contains the value <see cref="DotStyles.Radial" />, then a radial gradient fill is done. See also
        ///         the <see cref="DotGraphAttributes.GradientAngle" /> attribute for setting a gradient angle on the graph or on individual
        ///         clusters (<see cref="DotClusterAttributes.GradientAngle" />).
        ///     </para>
        ///     <para>
        ///         These fills work with any shape. For certain shapes, the style attribute can be set to do fills using more than 2 colors
        ///         (set the <see cref="DotStyles.Striped" /> shape, and use <see cref="DotMultiColor" /> as a color list definition).
        ///     </para>
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color used to fill the background of clusters, assuming that the style attribute of the graph (
        ///         <see cref="DotGraphAttributes.Style" />) or of individual clusters (<see cref="DotClusterAttributes.Style" />) contains
        ///         <see cref="DotStyles.Filled" />. If <see cref="FillColor" /> is not defined, <see cref="Color" /> is used. If
        ///         <see cref="Color" /> is not defined, <see cref="DotClusterAttributes.BackgroundColor" /> is used. If it is not defined
        ///         too, the default is used, except when the output format is MIF, which use black by default.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotGradientColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         style to <see cref="DotStyles.Radial" /> will cause a radial fill. If the second color is
        ///         <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the
        ///         <see cref="DotGraphAttributes.GradientAngle" /> attribute for setting a gradient angle on the graph or on individual
        ///         clusters (<see cref="DotClusterAttributes.GradientAngle" />).
        ///     </para>
        ///     <para>
        ///         Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a
        ///         <see cref="FillColor" />, this will override a <see cref="DotClusterAttributes.Color" /> or
        ///         <see cref="DotClusterAttributes.BackgroundColor" /> attribute set for the cluster.
        ///     </para>
        /// </summary>
        DotColorDefinition FillColor { get; set; }

        /// <summary>
        ///     Specifies the width of the pen, in points, used to draw the bounding box around clusters. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? BorderWidth { get; set; }

        /// <summary>
        ///     <para>
        ///         Color used to draw the bounding box around clusters (default: <see cref="System.Drawing.Color.Black" />). If not defined,
        ///         <see cref="Color" /> is used. If this is not defined, the default is used.
        ///     </para>
        ///     <para>
        ///         Note that a cluster inherits the root graph's attributes if defined. Thus, if <see cref="BorderColor" /> is set, it will
        ///         override a <see cref="DotClusterAttributes.Color" /> or <see cref="DotClusterAttributes.BackgroundColor" /> set for the
        ///         cluster.
        ///     </para>
        /// </summary>
        DotColor BorderColor { get; set; }

        /// <summary>
        ///     If true, allows edges between clusters (default: false). Specify a <see cref="DotEdgeEndpointAttributes.ClusterId" /> for an
        ///     edge's <see cref="DotEdgeAttributes.Head" /> or <see cref="DotEdgeAttributes.Tail" /> to attach it to the border of the
        ///     cluster with that identifier.
        /// </summary>
        bool? AllowEdgeClipping { get; set; }

        /// <summary>
        ///     Mode used for handling clusters (dot only; default: <see cref="DotClusterVisualizationMode.Bounded" />).
        /// </summary>
        DotClusterVisualizationMode? VisualizationMode { get; set; }
    }
}