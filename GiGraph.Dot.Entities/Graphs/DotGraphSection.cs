using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    public class DotGraphSection : DotCommonGraphSection
    {
        protected DotGraphSection(
            DotGraphAttributes attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters
        )
            : base(attributes, nodes, edges, subgraphs, clusters)
        {
        }

        protected DotGraphSection(DotGraphSection section)
            : base(section)
        {
        }

        public DotGraphSection()
            : base(new DotGraphAttributes())
        {
        }

        protected override DotAttributeCollection AttributeCollection => Attributes.Collection;

        /// <summary>
        ///     The attributes of the graph.
        /// </summary>
        public virtual DotGraphAttributes Attributes => (DotGraphAttributes) _attributes;
    }
}