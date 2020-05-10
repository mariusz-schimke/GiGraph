using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Graphs;

namespace Gigraph.Dot.Entities.Subgraphs
{
    /// <summary>
    /// Represents a subgraph as a collection of nodes constrained with a rank attribute.
    /// </summary>
    public class DotSubgraph : DotGraphBody
    {
        /// <summary>
        /// Gets or sets the unique identifier of the subgraph. Set null if no identifier should be used.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// The attributes of the subgraph. The only valid attribute for a non-cluster subgraph is rank.
        /// </summary>
        public new DotSubgraphAttributeCollection Attributes
        {
            get => (DotSubgraphAttributeCollection)base.Attributes;
            protected set => base.Attributes = value;
        }

        protected DotSubgraph()
        {
            Attributes = new DotSubgraphAttributeCollection();
        }

        /// <summary>
        /// Creates a new subgraph.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        public DotSubgraph(string id = null)
            : this()
        {
            Id = id;
        }

        // TODO: dodać metodę wytwórczą, która przyjmuje rank i pramams string[] id węzłów
    }
}
