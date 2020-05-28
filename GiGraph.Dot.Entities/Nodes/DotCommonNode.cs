using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract class DotCommonNode : IDotEntity
    {
        /// <summary>
        /// The attributes of the node or node group.
        /// </summary>
        public virtual IDotNodeAttributes Attributes { get; }

        protected DotCommonNode(IDotNodeAttributes attributes)
        {
            Attributes = attributes;
        }
    }
}
