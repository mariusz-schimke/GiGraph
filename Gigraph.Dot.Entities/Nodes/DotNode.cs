using Gigraph.Dot.Entities.Attributes.Collections;

namespace Gigraph.Dot.Entities.Nodes
{
    /// <summary>
    /// Represents a graph node.
    /// </summary>
    public class DotNode : IDotEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the node.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// The attributes of the node.
        /// </summary>
        public virtual DotNodeAttributeCollection Attributes { get; protected set; } = new DotNodeAttributeCollection();

        protected DotNode()
        {
        }

        /// <summary>
        /// The unique identifier of the node.
        /// </summary>
        /// <param name="id"></param>
        public DotNode(string id)
        {
            Id = id;
        }
    }
}
