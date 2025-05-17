using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Graphs.Attributes;

namespace GiGraph.Dot.Entities.Clusters.Collections;

public partial class DotGraphClusterCollection(DotGraphClustersAttributes graphClustersAttributes) : DotClusterCollection
{
    /// <summary>
    ///     Provides access to the global graph attributes applied to clusters.
    /// </summary>
    public DotEntityAttributesAccessor<IDotGraphClustersAttributes, DotGraphClustersAttributes> Attributes { get; } = new(graphClustersAttributes);
}