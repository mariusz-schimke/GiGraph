using System;
using GiGraph.Dot.Entities.Attributes.Collections.Node;

namespace GiGraph.Dot.Entities.Nodes
{
    /// <summary>
    ///     Represents a graph node.
    /// </summary>
    public class DotNode : DotNodeDefinition
    {
        protected DotNode(string id, IDotNodeAttributeCollection attributes)
            : base(attributes)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Node identifier cannot be null.");
        }

        /// <summary>
        ///     The unique identifier of the node.
        /// </summary>
        /// <param name="id"></param>
        public DotNode(string id)
            : this(id, new DotNodeAttributeCollection())
        {
        }

        /// <summary>
        ///     Gets or sets the unique identifier of the node.
        /// </summary>
        public virtual string Id { get; }

        /// <summary>
        ///     The attributes of the node.
        /// </summary>
        public override IDotNodeAttributeCollection Attributes => base.Attributes;

        protected override string GetOrderingKey()
        {
            return Id;
        }
    }
}