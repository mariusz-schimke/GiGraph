using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Subgraph;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Subgraphs
{
    /// <summary>
    ///     <para>
    ///         Represents a subgraph as a collection of nodes constrained with a rank attribute, that determines their layout. Use a
    ///         subgraph (<see cref="DotSubgraph" />) when you want to have more granular control on the layout and style of specific
    ///         nodes. However, when you want the nodes to be displayed together in a bounding box, use a cluster (
    ///         <see cref="DotCluster" />) instead.
    ///     </para>
    ///     <para>
    ///         Subgraph (<see cref="DotSubgraph" />) does not have any border or fill, as opposed to cluster subgraph (
    ///         <see cref="DotCluster" />), which supports them. However, it supports setting common style of nodes and edges within it,
    ///         as well as the layout of nodes (by the rank attribute).
    ///     </para>
    ///     <para>
    ///         Subgraph (<see cref="DotSubgraph" />) can also be used as a head or tail of an edge, in which case all nodes within them
    ///         are connected to the other side of the edge.
    ///     </para>
    /// </summary>
    public class DotSubgraph : DotCommonGraph<IDotSubgraphAttributeCollection>
    {
        protected DotSubgraph(
            string id,
            IDotSubgraphAttributeCollection attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters,
            IDotEdgeAttributeCollection edgeDefaults,
            DotGraphSectionCollection<IDotSubgraphAttributeCollection> subsections)
            : base(id, attributes, nodes, edges, subgraphs, clusters, edgeDefaults, subsections)
        {
        }

        protected DotSubgraph(
            string id,
            DotGraphSection<IDotSubgraphAttributeCollection> rootSection,
            DotGraphSectionCollection<IDotSubgraphAttributeCollection> subsections)
            : base(id, rootSection.Attributes, rootSection.Nodes, rootSection.Edges, rootSection.Subgraphs, rootSection.Clusters, rootSection.EdgeDefaults, subsections)
        {
        }

        /// <summary>
        ///     Creates a new subgraph.
        /// </summary>
        public DotSubgraph()
            : this(id: null, CreateSection(), new DotGraphSectionCollection<IDotSubgraphAttributeCollection>(CreateSection))
        {
        }

        /// <summary>
        ///     Creates a new subgraph.
        /// </summary>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        public DotSubgraph(DotRank rank)
            : this()
        {
            Attributes.Rank = rank;
        }

        /// <summary>
        ///     Creates a new subgraph with the specified nodes.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to add to the subgraph.
        /// </param>
        public static DotSubgraph FromNodes(params string[] nodeIds)
        {
            return FromNodes(nodeIds, rank: null);
        }

        /// <summary>
        ///     Creates a new subgraph with the specified nodes.
        /// </summary>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to add to the subgraph.
        /// </param>
        public static DotSubgraph FromNodes(DotRank rank, params string[] nodeIds)
        {
            return FromNodes(nodeIds, rank);
        }

        /// <summary>
        ///     Creates a new subgraph with the specified nodes.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to add to the subgraph.
        /// </param>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        public static DotSubgraph FromNodes(IEnumerable<string> nodeIds, DotRank? rank = null)
        {
            var result = rank.HasValue
                ? new DotSubgraph(rank.Value)
                : new DotSubgraph();

            if (nodeIds.Any())
            {
                result.Nodes.AddRange(nodeIds);
            }

            return result;
        }

        protected static DotGraphSection<IDotSubgraphAttributeCollection> CreateSection()
        {
            return Create(new DotSubgraphAttributeCollection());
        }
    }
}