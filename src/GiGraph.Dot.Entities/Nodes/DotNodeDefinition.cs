using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract partial class DotNodeDefinition : IDotEntity, IDotAnnotatable, IDotOrderable
    {
        protected DotNodeDefinition(DotNodeRootAttributes attributes)
        {
            Attributes = new DotEntityRootAttributesAccessor<IDotNodeAttributes, DotNodeRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the node.
        /// </summary>
        public DotEntityRootAttributesAccessor<IDotNodeAttributes, DotNodeRootAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation { get; set; }

        string IDotOrderable.OrderingKey => GetOrderingKey();

        protected abstract string GetOrderingKey();
    }
}