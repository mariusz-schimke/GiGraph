using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract class DotNodeDefinition : IDotOrderableEntity
    {
        /// <summary>
        /// The attributes of the node or node group.
        /// </summary>
        public virtual IDotNodeAttributes Attributes { get; }
        
        public virtual string Notes { get; set; }

        string IDotOrderableEntity.OrderingKey => GetOrderingKey();

        protected DotNodeDefinition(IDotNodeAttributes attributes)
        {
            Attributes = attributes;
        }

        protected abstract string GetOrderingKey();
    }
}
