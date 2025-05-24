using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public interface IDotClusterLayoutAttributes
{
    /// <summary>
    ///     Specifies the space between the nodes in the cluster and bounding box of the cluster. By default, this is 8 points.
    /// </summary>
    DotPoint? Padding { get; set; }

    /// <summary>
    ///     Gets or sets the rank constraints on the nodes in the cluster (dot only).
    /// </summary>
    DotRank? NodeRank { get; set; }

    /// <summary>
    ///     Gets or sets the sorting index of the cluster (default: 0). If <see cref="DotGraphLayoutAttributes.PackingMode"/> indicates
    ///     an array packing, this attribute specifies an insertion order among the components, with smaller values inserted first.
    /// </summary>
    int? SortIndex { get; set; }
}