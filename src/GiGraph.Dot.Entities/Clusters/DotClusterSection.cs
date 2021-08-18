using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Clusters
{
    public partial class DotClusterSection : DotCommonGraphSection
    {
        protected DotClusterSection(
            DotClusterRootAttributes attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters
        )
            : base(attributes, nodes, edges, subgraphs, clusters)
        {
        }

        protected DotClusterSection(DotClusterSection source)
            : base(source)
        {
        }

        public DotClusterSection()
            : base(new DotClusterRootAttributes())
        {
        }

        /// <summary>
        ///     The attributes of the cluster.
        /// </summary>
        public virtual DotClusterRootAttributes Attributes => (DotClusterRootAttributes) _attributes;

        protected override DotAttributeCollection AttributeCollection => Attributes.Collection;
    }
}