using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    public partial class DotGraphSection : DotCommonGraphSection
    {
        protected DotGraphSection(
            DotGraphRootAttributes attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotGraphClusterCollection clusters
        )
            : base(attributes, nodes, edges, subgraphs, clusters)
        {
        }

        protected DotGraphSection(DotGraphSection source)
            : base(source)
        {
        }

        private DotGraphSection(DotGraphRootAttributes attributes)
            : base(
                attributes,
                new DotSubgraphCollection(),
                new DotGraphClusterCollection(new DotGraphClusterAttributes(attributes))
            )
        {
        }

        public DotGraphSection()
            : this(new DotGraphRootAttributes())
        {
        }

        protected override DotAttributeCollection AttributeCollection => Attributes.Collection;

        /// <summary>
        ///     The attributes of the graph.
        /// </summary>
        public virtual DotGraphRootAttributes Attributes => (DotGraphRootAttributes) _attributes;

        /// <inheritdoc cref="DotCommonGraphSection.Clusters" />
        public new virtual DotGraphClusterCollection Clusters => (DotGraphClusterCollection) base.Clusters;
    }
}