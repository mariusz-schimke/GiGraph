using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Graphs.Style;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;

public interface IDotGraphClusterCommonStyleAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the color to use for the cluster (default: <see cref="System.Drawing.Color.Black" />).
    ///     </para>
    ///     <para>
    ///         If <see cref="DotGradientColor" /> is specified, with no weighted colors in its parameters (<see cref="DotColor" /> items
    ///         only), and the <see cref="DotGraphFillStyle.Filled" /> fill style is used, a linear gradient fill is done.
    ///     </para>
    ///     <para>
    ///         If <see cref="DotGradientColor" /> is used with weighted colors (see <see cref="DotWeightedColor" />), a degenerate
    ///         linear gradient fill is done. This essentially does a fill using two colors, with the
    ///         <see cref="DotWeightedColor.Weight" /> specifying how much of region is filled with each color.
    ///     </para>
    ///     <para>
    ///         If the fill style used is <see cref="DotGraphFillStyle.Radial" />, then a radial gradient fill is done. See also the
    ///         <see cref="DotGraphStyleAttributes.GradientFillAngle" /> attribute of graph
    ///         <see cref="IDotGraphRootAttributes.Canvas" /> for setting a gradient angle globally, or its
    ///         <see cref="IDotClusterStyleAttributes.GradientFillAngle" /> counterpart on individual clusters.
    ///     </para>
    ///     <para>
    ///         The fill style can also be set to do fills using more than 2 colors (set fill style to
    ///         <see cref="DotGraphFillStyle.Striped" />, and use <see cref="DotMulticolor" /> as a color list definition).
    ///     </para>
    /// </summary>
    DotColorDefinition? Color { get; set; }

    /// <summary>
    ///     <para>
    ///         Gets or sets the color used to fill the background of the cluster, assuming that the
    ///         <see cref="DotGraphFillStyle.Filled" /> fill style is specified (default: <see cref="System.Drawing.Color.Black" />).
    ///         If <see cref="FillColor" /> is not defined, <see cref="Color" /> is used. If <see cref="Color" /> is not defined,
    ///         <see cref="IDotClusterStyleAttributes.BackgroundColor" /> is used. If it is not defined too, the default is used, except when
    ///         the output format is MIF, which use black by default.
    ///     </para>
    ///     <para>
    ///         When <see cref="DotGradientColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
    ///         fill style to <see cref="DotGraphFillStyle.Radial" /> will cause a radial fill. If the second color is
    ///         <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the
    ///         <see cref="DotGraphStyleAttributes.GradientFillAngle" /> attribute on graph
    ///         <see cref="IDotGraphRootAttributes.Canvas" /> for setting a gradient angle globally, or its
    ///         <see cref="IDotClusterStyleAttributes.GradientFillAngle" /> counterpart on individual clusters.
    ///     </para>
    ///     <para>
    ///         Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a
    ///         <see cref="FillColor" />, this will override a <see cref="Color" /> or
    ///         <see cref="IDotClusterStyleAttributes.BackgroundColor" /> set for the cluster.
    ///     </para>
    /// </summary>
    DotColorDefinition? FillColor { get; set; }

    /// <summary>
    ///     Specifies the width of the pen, in points, used to draw the bounding box around clusters. The value is inherited by
    ///     subclusters. It has no effect on text. Default: 1.0, minimum: 0.0.
    /// </summary>
    double? BorderWidth { get; set; }

    /// <summary>
    ///     A color used to draw the bounding box around the cluster (default: <see cref="System.Drawing.Color.Black" />). If
    ///     <see cref="BorderColor" /> is not defined, <see cref="Color" /> is used. If this is not defined, the default is used. Note
    ///     that a cluster inherits the root graph's attributes if defined. Thus, if <see cref="BorderColor" /> is defined globally for
    ///     clusters, it will override a <see cref="Color" /> or <see cref="IDotClusterStyleAttributes.BackgroundColor" /> attribute set for
    ///     individual clusters.
    /// </summary>
    DotColor? BorderColor { get; set; }
}