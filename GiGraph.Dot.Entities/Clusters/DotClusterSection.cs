using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Clusters
{
    public class DotClusterSection : DotCommonGraphSection
    {
        protected DotClusterSection(
            DotClusterAttributes attributes,
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
            : base(new DotClusterAttributes())
        {
        }

        /// <summary>
        ///     The attributes of the cluster.
        /// </summary>
        public virtual DotClusterAttributes Attributes => (DotClusterAttributes) _attributes;

        protected override DotAttributeCollection AttributeCollection => Attributes.Collection;
    }
}