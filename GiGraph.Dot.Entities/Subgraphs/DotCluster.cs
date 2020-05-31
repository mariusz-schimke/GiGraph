using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Subgraphs
{
    /// <summary>
    /// Represents a cluster subgraph. A cluster subgraph is a special type of subgraph whose appearance can be customized (as opposed to <see cref="DotSubgraph"/>).
    /// If supported, the layout engine used to render it, will do the layout so that the nodes belonging to the cluster
    /// are drawn together, with the entire drawing of the cluster contained within a bounding rectangle.
    /// Note that cluster subgraphs are not part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.
    /// <para>
    ///     Cluster subgraphs (<see cref="DotCluster"/>) do not support setting custom node layout the way normal subgraphs (<see cref="DotSubgraph"/>) do,
    ///     but they do support setting common style of nodes and edges within them.
    /// </para>
    /// </summary>
    public class DotCluster : DotCommonSubgraph
    {
        /// <summary>
        /// The attributes of the cluster.
        /// </summary>
        public new IDotClusterAttributes Attributes => (IDotClusterAttributes)base.Attributes;

        protected DotCluster(string id,
            IDotClusterAttributes attributes,
            DotCommonNodeCollection nodes,
            DotCommonEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters,
            IDotNodeAttributes defaultNodeAttributes,
            IDotEdgeAttributes defaultEdgeAttributes)
            : base(id, attributes, nodes, edges, subgraphs, clusters, defaultNodeAttributes, defaultEdgeAttributes)
        {
        }

        /// <summary>
        /// Creates a new cluster subgraph.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        public DotCluster(string id = null)
            : this
              (
                  id,
                  new DotEntityAttributes(),
                  new DotCommonNodeCollection(),
                  new DotCommonEdgeCollection(),
                  new DotSubgraphCollection(),
                  new DotClusterCollection(),
                  new DotEntityAttributes(),
                  new DotEntityAttributes()
              )
        {
        }

        public static DotCluster FromNodes(IEnumerable<string> nodeIds, string id)
        {
            var result = new DotCluster(id);

            if (nodeIds.Any())
            {
                result.Nodes.AddRange(nodeIds);
            }

            return result;
        }
    }
}
