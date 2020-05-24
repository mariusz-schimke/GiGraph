using GiGraph.Dot.Entities.Attributes.Collections;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Nodes
{
    public abstract class DotCommonNode : IDotEntityWithIds
    {
        /// <summary>
        /// The attributes of the node or node group.
        /// </summary>
        public virtual IDotNodeAttributes Attributes { get; }

        IEnumerable<string> IDotEntityWithIds.Ids => GetNodeIds();

        protected DotCommonNode(IDotNodeAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the identifier of the node, or the identifiers of multiple nodes
        /// if the descendant class represents a group.
        /// </summary>
        protected abstract IEnumerable<string> GetNodeIds();
    }
}
