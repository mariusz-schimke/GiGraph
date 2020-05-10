using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Graphs;

namespace Gigraph.Dot.Entities.Subgraphs
{
    /// <summary>
    /// Represents a cluster subgraph.
    /// If supported, the layout engine used to render it, will do the layout so that the nodes belonging to the cluster
    /// are drawn together, with the entire drawing of the cluster contained within a bounding rectangle.
    /// Note that cluster subgraphs are not part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.
    /// </summary>
    public class DotCluster : DotGraphBody
    {
        /// <summary>
        /// Gets or sets the unique identifier of the subgraph. Set null if no identifier should be used.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// The attributes of the cluster.
        /// </summary>
        public new DotClusterAttributeCollection Attributes
        {
            get => (DotClusterAttributeCollection)base.Attributes;
            protected set => base.Attributes = value;
        }

        protected DotCluster()
        {
            Attributes = new DotClusterAttributeCollection();
        }

        /// <summary>
        /// Creates a new cluster subgraph.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        public DotCluster(string id = null)
            : this()
        {
            Id = id;
        }
    }
}
