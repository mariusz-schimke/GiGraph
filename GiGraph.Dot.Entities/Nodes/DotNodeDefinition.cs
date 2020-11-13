using GiGraph.Dot.Entities.Attributes.Collections.Node;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract class DotNodeDefinition : IDotEntity, IDotAnnotatable, IDotOrderable
    {
        protected DotNodeDefinition(DotNodeAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The attributes of the node or node group.
        /// </summary>
        public virtual DotNodeAttributes Attributes { get; }

        public virtual string Annotation { get; set; }

        string IDotOrderable.OrderingKey => GetOrderingKey();

        protected abstract string GetOrderingKey();
    }
}