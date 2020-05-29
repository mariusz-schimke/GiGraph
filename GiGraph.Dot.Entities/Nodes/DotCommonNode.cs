using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract class DotCommonNode : IDotOrderableEntity
    {
        /// <summary>
        /// The attributes of the node or node group.
        /// </summary>
        public virtual IDotNodeAttributes Attributes { get; }

        string IDotOrderableEntity.OrderingKey => GetOrderingKey();

        protected DotCommonNode(IDotNodeAttributes attributes)
        {
            Attributes = attributes;
        }

        protected abstract string GetOrderingKey();
    }
}
