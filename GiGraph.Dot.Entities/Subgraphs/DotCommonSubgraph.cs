using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public abstract class DotCommonSubgraph : DotCommonGraph
    {
        protected DotCommonSubgraph(
            string id,
            IDotAttributeCollection attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotCommonSubgraphCollection subgraphs,
            IDotNodeAttributes defaultNodeAttributes,
            IDotEdgeAttributes defaultEdgeAttributes)
            : base(id, attributes, nodes, edges, subgraphs, defaultNodeAttributes, defaultEdgeAttributes)
        {
        }
    }
}
