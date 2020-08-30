using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Entities.Types.Scaling;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphLevelClusterAttributes
    {
        /// <summary>
        ///     Gets or sets the color to use for clusters (default: <see cref="System.Drawing.Color.Black" />). If
        ///     <see cref="DotMultiColor" /> is used, with no weighted colors in its color collection (<see cref="DotColor" /> items only),
        ///     and the <see cref="Style" /> is <see cref="DotStyles.Filled" />, a linear gradient fill is done using the first two colors.
        ///     If weighted colors are present (see <see cref="DotWeightedColor" />), a degenerate linear gradient fill is done. This
        ///     essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight" /> specifying how much of region is
        ///     filled with each color. If the <see cref="Style" /> attribute contains the value <see cref="DotStyles.Radial" />, then a
        ///     radial gradient fill is done. These fills work with any shape. For certain shapes, the <see cref="Style" /> attribute can be
        ///     set to do fills using more than 2 colors (see <see cref="DotStyles.Striped" />).
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color used to fill the background of clusters, assuming that their
        ///         <see cref="IDotClusterAttributes.Style" /> is <see cref="DotStyles.Filled" />. If <see cref="FillColor" /> is not
        ///         defined, <see cref="Color" /> is used. If <see cref="Color" /> is not defined,
        ///         <see cref="IDotClusterAttributes.BackgroundColor" /> is used. If it is not defined too, the default is used, except when
        ///         the output format is MIF, which use black by default.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotMultiColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyles.Radial" /> will cause a radial fill. At present, only two colors are used.
        ///         If the second color is missing, the default color is used for it. See also the <see cref="GradientAngle" /> attribute for
        ///         setting the gradient angle. Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph
        ///         has defined a fill color, this will override a <see cref="IDotClusterAttributes.Color" /> or
        ///         <see cref="IDotClusterAttributes.BackgroundColor" /> attribute set for the cluster.
        ///     </para>
        /// </summary>
        DotColorDefinition FillColor { get; set; }

        /// <summary>
        ///     Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges and clusters. The
        ///     value is inherited by subclusters. It has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        ///     Color used to draw the bounding box around clusters (default: <see cref="System.Drawing.Color.Black" />). If
        ///     <see cref="PenColor" /> is not defined, <see cref="Color" /> is used. If this is not defined, the default is used. Note that
        ///     a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a pen color, this will
        ///     override a <see cref="IDotClusterAttributes.Color" /> or <see cref="IDotClusterAttributes.BackgroundColor" /> attribute set
        ///     for the cluster.
        /// </summary>
        Color? PenColor { get; set; }
        
        /// <summary>
        ///     If true, allows edges between clusters (default: false). Use the <see cref="IDotEdgeAttributes.HeadClusterId" /> or
        ///     <see cref="IDotEdgeAttributes.TailClusterId" /> edge attributes to attach an edge head or tail to a cluster.
        /// </summary>
        bool? EdgesBetweenClusters { get; set; }

        /// <summary>
        ///     Mode used for handling clusters (dot only; default: <see cref="DotClusterMode.Bounded" />).
        /// </summary>
        DotClusterMode? ClusterMode { get; set; }

        /// <summary>
        ///     Gets or sets the sorting index of the graph (default: 0). If <see cref="PackingMode" /> indicates an array packing, this
        ///     attribute specifies an insertion order among the components, with smaller values inserted first.
        /// </summary>
        int? SortIndex { get; set; }
    }
}