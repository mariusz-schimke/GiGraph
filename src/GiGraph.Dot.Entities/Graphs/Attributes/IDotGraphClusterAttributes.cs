using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Types.Clusters;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public interface IDotGraphClusterAttributes : IDotGraphClusterCommonAttributes
    {
        /// <summary>
        ///     If true, allows edges between clusters (dot only, default: false). Specify a
        ///     <see cref="IDotEdgeEndpointAttributes.ClusterId" /> for an edge's head or tail to attach it to the border of the cluster with
        ///     that identifier.
        /// </summary>
        bool? AllowEdgeClipping { get; set; }

        /// <summary>
        ///     Mode used for handling clusters (dot only; default: <see cref="DotClusterVisualizationMode.Bounded" />).
        /// </summary>
        DotClusterVisualizationMode? VisualizationMode { get; set; }
    }
}