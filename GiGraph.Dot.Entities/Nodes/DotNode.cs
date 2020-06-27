using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Nodes
{
    /// <summary>
    /// Represents a graph node.
    /// </summary>
    public class DotNode : DotNodeDefinition, IDotFillable
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
            : this(id, new DotEntityAttributes())
        {
        }

        protected override string GetOrderingKey()
        {
            return Id;
        }

        void IDotFillable.Fill(DotColorDefinition value)
        {
            Attributes.Style = Attributes.Style.GetValueOrDefault(DotStyle.Filled) | DotStyle.Filled;
            Attributes.FillColor = value;
        }
    }
}