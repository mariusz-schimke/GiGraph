using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Entities.Nodes;

namespace Gigraph.Dot.Entities.Subgraphs
{
    public abstract class DotCommonSubgraph : DotCommonGraph
    {
        protected DotCommonSubgraph(
            string id,
            DotAttributeCollection attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotCommonSubgraphCollection subgraphs,
            DotNodeAttributeCollection defaultNodeAttributes,
            DotEdgeAttributeCollection defaultEdgeAttributes)
            : base(id, attributes, nodes, edges, subgraphs, defaultNodeAttributes, defaultEdgeAttributes)
        {
        }
    }
}
