using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Nodes;

namespace Gigraph.Dot.Entities.Subgraphs
{
    /// <summary>
    /// Represents a cluster subgraph. A cluster is a special type of subgraph whose appearance can be customized (as opposed to <see cref="DotSubgraph"/>).
    /// If supported, the layout engine used to render it, will do the layout so that the nodes belonging to the cluster
    /// are drawn together, with the entire drawing of the cluster contained within a bounding rectangle.
    /// Note that cluster subgraphs are not part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.
    /// </summary>
    public class DotCluster : DotCommonSubgraph
    {
        /// <summary>
        /// The attributes of the cluster.
        /// </summary>
        public new DotClusterAttributeCollection Attributes => (DotClusterAttributeCollection)base.Attributes;

        protected DotCluster(string id, DotClusterAttributeCollection attributes, DotNodeCollection nodes, DotEdgeCollection edges, DotCommonSubgraphCollection subgraphs)
            : base(id, attributes, nodes, edges, subgraphs)
        {
        }

        /// <summary>
        /// Creates a new cluster subgraph.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        public DotCluster(string id = null)
            : this(id, new DotClusterAttributeCollection(), new DotNodeCollection(), new DotEdgeCollection(), new DotCommonSubgraphCollection())
        {
        }
    }
}
