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
            DotGraphSubgraphCollection subgraphs,
            DotGraphClusterCollection clusters
        )
            : base(attributes, nodes, edges, subgraphs, clusters)
        {
        }

        protected DotGraphSection(DotGraphSection source)
            : base(source)
        {
        }

        private DotGraphSection(DotGraphAttributes attributes)
            : base(
                attributes,
                new DotGraphSubgraphCollection(new DotGraphSubgraphAttributes(attributes)),
                new DotGraphClusterCollection(new DotGraphClusterAttributes(attributes))
            )
        {
        }

        public DotGraphSection()
            : this(new DotGraphAttributes())
        {
        }

        protected override DotAttributeCollection AttributeCollection => Attributes.Collection;

        /// <summary>
        ///     The attributes of the graph.
        /// </summary>
        public virtual DotGraphAttributes Attributes => (DotGraphAttributes) _attributes;

        /// <inheritdoc cref="DotCommonGraphSection.Clusters" />
        public new DotGraphClusterCollection Clusters => (DotGraphClusterCollection) base.Clusters;

        /// <inheritdoc cref="DotCommonGraphSection.Subgraphs" />
        public new DotGraphSubgraphCollection Subgraphs => (DotGraphSubgraphCollection) base.Subgraphs;
    }
}