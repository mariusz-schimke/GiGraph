using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Clusters;

namespace GiGraph.Dot.Entities.Clusters.Collections;

public partial class DotGraphClusterCollection : IDotGraphClustersRootAttributes
{
    /// <inheritdoc cref="IDotGraphClustersRootAttributes.Style"/>
    public DotGraphClustersStyleAttributes Style => Attributes.Implementation.Style;

    /// <inheritdoc cref="IDotGraphClustersAttributes.EnableEdgeClipping"/>
    public virtual bool? EnableEdgeClipping
    {
        get => Attributes.Implementation.EnableEdgeClipping;
        set => Attributes.Implementation.EnableEdgeClipping = value;
    }

    /// <inheritdoc cref="IDotGraphClustersAttributes.VisualizationMode"/>
    public virtual DotClusterVisualizationMode? VisualizationMode
    {
        get => Attributes.Implementation.VisualizationMode;
        set => Attributes.Implementation.VisualizationMode = value;
    }
}