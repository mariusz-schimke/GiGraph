using Gigraph.Dot.Entities.Graphs;

namespace Gigraph.Dot.Entities.Subgraphs
{
    public class DotSubgraph : DotGraphBody
    {
        /// <summary>
        /// Gets or sets the unique identifier of the subgraph. Set null if no identifier should be used.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets or sets a value that determines whether the subgraph is a cluster subgraph.
        /// If supported, the layout engine used to render the graph, will do the layout so that the nodes belonging to the cluster 
        /// are drawn together, with the entire drawing of the cluster contained within a bounding rectangle.
        /// Note that cluster subgraphs are not part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.
        /// </summary>
        public virtual bool IsCluster { get; set; }

        protected DotSubgraph()
        {
        }

        /// <summary>
        /// Creates a new subgraph.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        /// <param name="isCluster">Determines whether the subgraph is a cluster subgraph.
        /// If supported, the layout engine used to render the graph, will do the layout so that the nodes belonging to the cluster 
        /// are drawn together, with the entire drawing of the cluster contained within a bounding rectangle.
        /// Note that cluster subgraphs are not part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.</param>
        public DotSubgraph(string id = null, bool isCluster = true)
        {
            Id = id;
            IsCluster = isCluster;
        }
    }
}
