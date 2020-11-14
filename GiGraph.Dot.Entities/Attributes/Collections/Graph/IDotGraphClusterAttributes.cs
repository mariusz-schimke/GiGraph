using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphClusterAttributes : IDotGraphClusterCommonAttributes
    {
        /// <summary>
        ///     If true, allows edges between clusters (dot only, default: false). Specify a <see cref="DotEdgeEndpointAttributes.ClusterId" /> for an
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