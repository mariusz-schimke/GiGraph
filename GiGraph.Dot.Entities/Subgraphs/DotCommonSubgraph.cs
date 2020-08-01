using GiGraph.Dot.Entities.Attributes.Collections;
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
            IDotNodeAttributeCollection defaultNodeAttributes,
            IDotEdgeAttributeCollection defaultEdgeAttributes)
            : base(id, attributes, nodes, edges, subgraphs, clusters, defaultNodeAttributes, defaultEdgeAttributes)
        {
        }
    }
}