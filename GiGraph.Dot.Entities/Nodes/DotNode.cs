using GiGraph.Dot.Entities.Attributes.Collections;
using System;

namespace GiGraph.Dot.Entities.Nodes
{
    /// <summary>
    /// Represents a graph node.
    /// </summary>
    public class DotNode : DotNodeDefinition
    {
        /// <summary>
        /// Gets or sets the unique identifier of the node.
        /// </summary>
        public virtual string Id { get; }

        /// <summary>
        /// The attributes of the node.
        /// </summary>
        public override IDotNodeAttributes Attributes => base.Attributes;

        protected DotNode(string id, IDotNodeAttributes attributes)
            : base(attributes)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Node identifier cannot be null.");
        }

        /// <summary>
        /// The unique identifier of the node.
        /// </summary>
        /// <param name="id"></param>
        public DotNode(string id)
            : this(id, new DotNodeAttributes())
        {
        }

        protected override string GetOrderingKey()
        {
            return Id;
        }
    }
}