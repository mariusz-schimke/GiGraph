using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public abstract class DotCommonSubgraph : DotCommonGraph
    {
        protected DotCommonSubgraph(
            string id,
            IDotAttributeCollection attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters,
            IDotNodeAttributeCollection nodeDefaults,
            IDotEdgeAttributeCollection edgeDefaults)
            : base(id, attributes, nodes, edges, subgraphs, clusters, nodeDefaults, edgeDefaults)
        {
        }
    }
}