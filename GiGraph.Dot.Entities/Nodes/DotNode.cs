using GiGraph.Dot.Entities.Attributes.Collections;
using System;

namespace GiGraph.Dot.Entities.Nodes
{
    /// <summary>
    /// Represents a graph node.
    /// </summary>
    public class DotNode : DotCommonNode
    {
        protected string _id;

        /// <summary>
        /// Gets or sets the unique identifier of the node.
        /// </summary>
        public virtual string Id
        {
            get => _id;
            set => _id = value ?? throw new ArgumentNullException(nameof(Id), "Node identifier cannot be null.");
        }

        /// <summary>
        /// The attributes of the node.
        /// </summary>
        public override IDotNodeAttributes Attributes => base.Attributes;

        protected DotNode(string id, IDotNodeAttributes attributes)
            : base(attributes)
        {
            Id = id;
        }

        /// <summary>
        /// The unique identifier of the node.
        /// </summary>
        /// <param name="id"></param>
        public DotNode(string id)
            : this(id, new DotEntityAttributes())
        {
        }
    }
}
