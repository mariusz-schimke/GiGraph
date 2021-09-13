using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract partial class DotNodeDefinition : IDotEntity, IDotAnnotatable, IDotOrderable
    {
        protected DotNodeDefinition(DotNodeRootAttributes attributes)
        {
            Attributes = new DotEntityRootAttributes<IDotNodeRootAttributes, DotNodeRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the node.
        /// </summary>
        public virtual DotEntityRootAttributes<IDotNodeRootAttributes, DotNodeRootAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation { get; set; }

        string IDotOrderable.OrderingKey => GetOrderingKey();

        protected abstract string GetOrderingKey();
    }
}