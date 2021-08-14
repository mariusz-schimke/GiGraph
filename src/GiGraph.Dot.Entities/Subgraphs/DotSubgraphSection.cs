using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public partial class DotSubgraphSection : DotCommonGraphSection, IDotSubgraphAttributes
    {
        protected DotSubgraphSection(
            DotSubgraphAttributes attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters
        )
            : base(attributes, nodes, edges, subgraphs, clusters)
        {
        }

        protected DotSubgraphSection(DotSubgraphSection source)
            : base(source)
        {
        }

        public DotSubgraphSection()
            : base(new DotSubgraphAttributes())
        {
        }

        /// <summary>
        ///     The attributes of the subgraph.
        /// </summary>
        public virtual DotSubgraphAttributes Attributes => (DotSubgraphAttributes) _attributes;

        protected override DotAttributeCollection AttributeCollection => Attributes.Collection;
    }
}