using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract partial class DotNodeDefinition : IDotEntity, IDotAnnotatable, IDotOrderable
    {
        protected DotNodeDefinition(DotNodeAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the node or node group.
        /// </summary>
        public virtual DotNodeAttributes Attributes { get; }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation { get; set; }

        string IDotOrderable.OrderingKey => GetOrderingKey();

        protected abstract string GetOrderingKey();
    }
}