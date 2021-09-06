using System;
using GiGraph.Dot.Entities.Nodes.Attributes;

namespace GiGraph.Dot.Entities.Nodes
{
    /// <summary>
    ///     Represents a graph node.
    /// </summary>
    public class DotNode : DotNodeDefinition
    {
        protected DotNode(string id, DotNodeRootAttributes attributes)
            : base(attributes)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Node identifier must not be null.");
        }

        /// <summary>
        ///     The unique identifier of the node.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the node.
        /// </param>
        public DotNode(string id)
            : this(id, new DotNodeRootAttributes())
        {
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the node.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        ///     The attributes of the node.
        /// </summary>
        public override DotNodeRootAttributes Attributes => base.Attributes;

        protected override string GetOrderingKey()
        {
            return Id;
        }
    }
}